using System.Net.Mime;
using FrontendBFF.Api.Dto;
using FrontendBFF.Api.Mappers;
using FrontendBFF.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace FrontendBFF.Api.Controllers;

[ApiController]
[Route("account")]
public class AccountController : ControllerBase
{
    private readonly ILogger<AccountController> _logger;
    private readonly IAccountService _accountService;

    public AccountController(ILogger<AccountController> logger, IAccountService accountService )
    {
        _logger = logger;
        _accountService = accountService;
    }

    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(AccountDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post([FromBody] AccountDto account)
    {
        _logger.LogInformation("Post invoked");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            return Ok(
                AccountMapper.AccountToAccountDto(await _accountService.CreateAccount(
                    AccountMapper.AccountDtoToAccount(account))));
        }
        catch (Exception e)
        {
            _logger.LogError("{E}", e);
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }


}