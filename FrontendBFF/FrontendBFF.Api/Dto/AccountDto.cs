using System.ComponentModel.DataAnnotations;

namespace FrontendBFF.Api.Dto;

public class AccountDto
{
    public long Id { get; set; }
    [Required]
    public long ProfileId { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Email { get; set; }
}