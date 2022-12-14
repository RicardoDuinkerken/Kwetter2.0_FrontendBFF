using System.ComponentModel.DataAnnotations;

namespace FrontendBFF.Api.Dto.ProfileDto;

public class CreateProfileDto
{
    [Required]
    public string Username { get; set; }
}