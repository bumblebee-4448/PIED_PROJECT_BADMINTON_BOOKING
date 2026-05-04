using Microsoft.AspNetCore.Mvc;
using Rallyhub.Service.Transaction;

namespace Rallyhub.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly IService _transactionService;
    public TransactionController(IService transactionService)
    {
        _transactionService = transactionService;
    }
    
    
}