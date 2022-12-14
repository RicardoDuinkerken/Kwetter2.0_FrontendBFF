using System.Net.Mime;
using FrontendBFF.Api.Dto;
using FrontendBFF.Api.Dto.KwetDto;
using FrontendBFF.Api.Dto.ProfileDto;
using FrontendBFF.Api.Mappers;
using FrontendBFF.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FrontendBFF.Api.Controllers;

[ApiController]
[Route("kwet")]
public class KwetController : ControllerBase
{
    private readonly ILogger<KwetController> _logger;
    private readonly IKwetService _kwetService;

    public KwetController(ILogger<KwetController> logger, IKwetService kwetService )
    {
        _logger = logger;
        _kwetService = kwetService;
    }
    
    [HttpPut]
    [Route("createKwet")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ChangeUsernameDto[]), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Put([FromBody] CreateKwetDto createKwetDto)
    {
        _logger.LogInformation("Put Create KWet invoked");

        try
        {
            return Ok(
                KwetMapper.ProfileToCreateProfileDto(await _kwetService.CreateKwet(KwetMapper.CreateKwetDtoToKwet(createKwetDto))));
        }
        catch (Exception e)
        {
            _logger.LogError("{E}", e);
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
    
    [HttpPut]
    [Route("updateKwet")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ChangeUsernameDto[]), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Put([FromBody] UpdateKwetDto updateKwetDto)
    {
        _logger.LogInformation("Put Update Kwet invoked");

        try
        {
            return Ok(
                KwetMapper.KwetToUpdateKwetDto(await _kwetService.UpdateKwet(KwetMapper.UpdateKwetDtoToKwet(updateKwetDto))));
        }
        catch (Exception e)
        {
            _logger.LogError("{E}", e);
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}