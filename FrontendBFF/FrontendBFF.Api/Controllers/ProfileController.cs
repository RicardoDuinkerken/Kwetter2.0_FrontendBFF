using System.Net.Mime;
using FrontendBFF.Api.Dto;
using FrontendBFF.Api.Dto.ProfileDto;
using FrontendBFF.Api.Mappers;
using FrontendBFF.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FrontendBFF.Api.Controllers;

[ApiController]
[Route("profile")]
public class ProfileController : ControllerBase
{
    private readonly ILogger<ProfileController> _logger;
    private readonly IProfileService _profileService;

    public ProfileController(ILogger<ProfileController> logger, IProfileService profileService )
    {
        _logger = logger;
        _profileService = profileService;
    }
    
    [HttpPut]
    [Route("createProfile")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ChangeUsernameDto[]), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Put([FromBody] CreateProfileDto createProfileDto)
    {
        _logger.LogInformation("Put Create Profile invoked");

        try
        {
            return Ok(
                ProfileMapper.ProfileToCreateProfileDto(await _profileService.CreateProfile(ProfileMapper.CreateProfileDtoToProfile(createProfileDto))));
        }
        catch (Exception e)
        {
            _logger.LogError("{E}", e);
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
    
    [HttpPut]
    [Route("updateProfile")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ChangeUsernameDto[]), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Put([FromBody] UpdateProfileDto updateProfileDto)
    {
        _logger.LogInformation("Put Update Profile invoked");

        try
        {
            return Ok(
                ProfileMapper.ProfileToUpdateProfileDto(await _profileService.UpdateProfile(ProfileMapper.UpdateProfileDtoToProfile(updateProfileDto))));
        }
        catch (Exception e)
        {
            _logger.LogError("{E}", e);
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
    
}