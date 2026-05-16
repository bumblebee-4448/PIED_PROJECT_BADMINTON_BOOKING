using Org.BouncyCastle.Ocsp;

namespace Rallyhub.Service.SystemReport;

public interface IService
{
    public Task<string> CreateSystemReport(Request.CreateSystemReportRequest request);
    public Task<Base.Response.PageResult<Response.GetSystemReportResponse>> GetSystemReport(Request.GetSystemReportRequest request);
    public Task SubmitReportReply(Request.SubmitReportReplyRequest request);
}