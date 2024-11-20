using Core;
using Core.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CustomerController : BaseController
{
    private readonly CustomerService _customerService;
    private readonly LoanService _loanService;
    public CustomerController(CustomerService customerService, LoanService loanService)
    {
        _customerService = customerService;
        _loanService = loanService;
    }

    [HttpPost("createOrGet")]
    public async Task<IActionResult> CreateOrGetCustomer(CreateCustomerRequest request)
    {
        var userId = await _customerService.CreateOrGateUserId(request);
        return Ok(new { UserId = userId });
    }

    [HttpPost("CreateLoan")]
    public async Task<IActionResult> CreateLoan(CreateLoanRequest request)
    {
        var loanId = await _loanService.CreateLoan(request);
        return Ok(new { LoanId = loanId });
    }

    [HttpPost("GetLoanBalance")]
    public async Task<IActionResult> GetLoanBalance(LoanBalanceRequest request)
    {
        var response = await _loanService.GetLoanBalance(request);
        return Ok(response);
    }
}