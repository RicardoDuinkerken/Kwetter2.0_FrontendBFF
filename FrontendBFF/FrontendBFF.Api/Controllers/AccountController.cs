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
    
    [HttpGet]
    [Route("hasProfile/{id}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(HasProfileDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status501NotImplemented)]
    public async Task<IActionResult> Get([FromRoute] long id)
    {
        _logger.LogInformation("Get hasProfile Invoked with id: {Id}", id);
        if (id < 1)
        {
            return BadRequest($"Value of {nameof(id)} must be above 0");
        }

        try
        {
            return Ok(await _accountService.HasProfile(id));
        }
        catch (Exception e)
        {
            _logger.LogError("{E}", e);
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
    
    [HttpGet]
    [Route("usernameAvailable/{username}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(IsAvailableUsernameDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status501NotImplemented)]
    public async Task<IActionResult> Get([FromRoute] string username)
    {
        _logger.LogInformation("Get UsernameAvailable Invoked with id: {Username}", username);

        try
        {
            return Ok(await _accountService.CheckAvailabilityUsername(username));
        }
        catch (Exception e)
        {
            _logger.LogError("{E}", e);
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }


}