using System.ComponentModel.DataAnnotations;

namespace FrontendBFF.Api.Dto.KwetDto;

public class UpdateKwetDto
{

    [Required]
    public long Id { get; set; }
    public string Username { get; set; }
    public string Content { get; set; }
}