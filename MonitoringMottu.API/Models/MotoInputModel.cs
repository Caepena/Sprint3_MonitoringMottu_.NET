using System.ComponentModel.DataAnnotations;

namespace MonitoringMottu.API.Models;

public class MotoInputModel
{
    [Required]
    public required string Modelo { get; set; }
    
    [Required]
    public required string Cor { get; set; }
    
    [Required]
    public required string Marca { get; set; }
    
    [Required]
    [RegularExpression(@"^(?i)(?:[A-Z]{3}\d{4}|[A-Z]{3}\d[A-Z]\d{2})$",
        ErrorMessage = "Placa inválida. Use o formato AAA1234 ou AAA1A23 (sem hífen).")]
    public required string Placa { get; set; }
    
    [Required]
    public required Guid GaragemId { get; set; }
}