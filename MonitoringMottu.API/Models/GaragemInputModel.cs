using System.ComponentModel.DataAnnotations;

namespace MonitoringMottu.API.Models;

public class GaragemInputModel
{
    [Required]
    public required string Endereco { get; set; }
    
    [Required]
    public required int Capacidade { get; set; }
    
    [Required]
    public required string Responsavel { get; set; }
}