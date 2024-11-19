using Core;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CustomerController : BaseController
{
    private readonly UserService _userService;

    public CustomerController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("createOrGet")]
    public async Task<IActionResult> CreateOrGetCustomer(CreateCustomerRequest request)
    {
        var userId = await _userService.CreateOrGateUserId(request);
        return Ok(new { UserId = userId });
    }
}