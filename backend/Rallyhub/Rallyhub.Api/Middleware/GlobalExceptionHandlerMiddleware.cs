using Rallyhub.Service.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Rallyhub.Api.Middleware;

public class GlobalExceptionHandlerMiddleware : IMiddleware
{
    private readonly IHostEnvironment _environment;
    //cho biết đc phiên bản dev hay production
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;
    //giúp in, er, infor,..

    public GlobalExceptionHandlerMiddleware(
        IHostEnvironment environment,
        ILogger<GlobalExceptionHandlerMiddleware> logger)
    {
        _environment = environment;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var (statusCode, errorType, englishMessage) = MapException(ex);

            if (statusCode >= StatusCodes.Status500InternalServerError)
            {
                _logger.LogError(ex, "Backend Error occurred while processing request {Path}", context.Request.Path);
            }
            else
            {
                _logger.LogWarning(ex, "{ErrorType} occurred while processing request {Path}: {Message}", errorType, context.Request.Path, ex.Message);
            }

            if (context.Response.HasStarted)
            {
                _logger.LogWarning("The response has already started, the global exception middleware will not write an error response");
                throw;
            }

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var response = ApiResponseFactory.ErrorResponse(
                message: englishMessage,
                errors: new 
                { 
                    errorType = errorType, 
                    originalMessage = GetDeepestMessage(ex), 
                    detail = _environment.IsDevelopment() ? $"Error: {GetDeepestMessage(ex)} | Location: {GetErrorLocation(ex)}" : null 
                },
                traceId: context.TraceIdentifier);

            await context.Response.WriteAsJsonAsync(response);
        }
    }

    private static (int StatusCode, string ErrorType, string EnglishMessage) MapException(Exception ex)
    {
        if (ErrorMappingConfig.BusinessErrors.TryGetValue(ex.Message, out var mapped))
        {
            return (mapped.StatusCode, "User Error / Business Logic", mapped.EnglishMessage);
        }

        return ex switch
        {
            ArgumentException => (StatusCodes.Status400BadRequest, "Frontend Error / Invalid Input", "Invalid arguments provided. Please check your input data."),
            InvalidOperationException => (StatusCodes.Status400BadRequest, "User Error / Invalid Operation", "The requested operation is invalid in the current state."),
            UnauthorizedAccessException => (StatusCodes.Status401Unauthorized, "User Error / Unauthorized", "You do not have permission to access this resource."),
            KeyNotFoundException => (StatusCodes.Status404NotFound, "User Error / Not Found", "The requested resource was not found."),
            
            DbUpdateConcurrencyException => (StatusCodes.Status409Conflict, "Backend Error / Database Conflict", "Data has been modified by another process. Please try again."),
            DbUpdateException => (StatusCodes.Status400BadRequest, "Backend Error / Database Error", "Database operation failed, possibly due to a constraint violation."),
            NotImplementedException => (StatusCodes.Status501NotImplemented, "Backend Error / Not Implemented", "This feature is not yet implemented by the backend."),
            
            _ => (StatusCodes.Status500InternalServerError, "Backend Error / Internal Server Error", "An unexpected internal server error occurred.")
        };
    }

    private static string GetDeepestMessage(Exception ex)
    {
        var current = ex;
        while (current.InnerException != null)
        {
            current = current.InnerException;
        }
        return current.Message;
    }

    private static string GetErrorLocation(Exception ex)
    {
        if (string.IsNullOrEmpty(ex.StackTrace)) return "Unknown location";

        var lines = ex.StackTrace.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        var relevantLine = lines.FirstOrDefault(l => l.Contains("Rallyhub"))?.Trim();

        if (relevantLine != null)
        {
            var match = System.Text.RegularExpressions.Regex.Match(relevantLine, @"in .*\\([^\\]+\.cs:line \d+)");
            return match.Success ? match.Groups[1].Value : relevantLine;
        }

        return "Unknown location";
    }
}