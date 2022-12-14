using System.ComponentModel.DataAnnotations;

namespace FrontendBFF.Api.Dto.KwetDto;

public class CreateKwetDto
{
    [Required]
    public string Username { get; set; }

    public string Content { get; set; }
}