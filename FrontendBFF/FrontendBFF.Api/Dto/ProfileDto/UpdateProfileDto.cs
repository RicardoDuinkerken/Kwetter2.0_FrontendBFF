using System.ComponentModel.DataAnnotations;

namespace FrontendBFF.Api.Dto.ProfileDto;

public class UpdateProfileDto
{
    [Required]
    public long Id { get; set; }
    public string Username { get; set; }
    public string Location { get; set; }
    public string Age{ get; set; }
    public string WebLink { get; set; }
    public string Bio { get; set; }
}