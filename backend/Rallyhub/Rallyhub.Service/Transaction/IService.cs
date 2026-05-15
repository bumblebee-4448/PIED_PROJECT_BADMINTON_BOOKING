namespace Rallyhub.Service.Transaction;

public interface IService
{
    // public Task<bool> CheckTotalTransactions(Guid userId);
    public Task<bool> CreateTransaction(Request.CreateTransactionRequest request);
    public Task<Base.Response.PageResult<Response.GetTransactionResponse>> GetTransaction(Base.Request.PagingDay paginDay);
    public Task<Base.Response.PageResult<Response.AdminGetTransactionResponse>> AdminGetTransaction(Guid? userId ,Base.Request.PagingDay paginDay);
    public Task<List<Response.GetTransactionResponse>> GetTransactionByBookingId(Guid bookingId);
}