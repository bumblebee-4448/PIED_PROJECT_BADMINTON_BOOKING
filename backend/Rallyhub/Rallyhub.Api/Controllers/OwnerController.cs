using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Rallyhub.Api.Extention;
using Rallyhub.Service.Owner;

namespace Rallyhub.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class OwnerController : ControllerBase
{
    private readonly IService _ownerService;

    public OwnerController(IService ownerService)
    {
        _ownerService = ownerService;
    }

}