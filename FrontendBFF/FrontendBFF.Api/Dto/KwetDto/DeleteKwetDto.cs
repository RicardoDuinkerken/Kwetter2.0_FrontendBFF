using System.ComponentModel.DataAnnotations;

namespace FrontendBFF.Api.Dto.KwetDto;

public class DeleteKwetDto
{
    [Required]
    public long Id { get; set; }
}