using System.ComponentModel.DataAnnotations;

namespace Core.Messages;
// TODO extract whole dir to sep project
public class RabbitSettings
{
    public const string SectionName = "RabbitSettings";
    
    [Required]
    public string ConnectionString { get; init; }
    
    [Required]
    public string Host { get; init; }
    
    [Required]
    public string Password { get; init; }

}
