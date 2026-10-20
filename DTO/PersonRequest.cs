using System.ComponentModel.DataAnnotations;

namespace RestASPNET.Api.DTO;

public class PersonRequest()
{
    [Required]
    [StringLength(80)]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [StringLength(80)]
    public string LastName { get; set; } = string.Empty;
    [Required]
    [StringLength(100)]
    public string Address { get; set; } = string.Empty;
    [Required]
    [StringLength(6)]
    public string Gender { get; set; } = string.Empty;
}