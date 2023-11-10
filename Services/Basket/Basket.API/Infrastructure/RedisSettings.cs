using System.ComponentModel.DataAnnotations;

namespace Basket.API.Infrastructure;

public sealed class RedisSettings
{
    public const string SectionName = "RedisSettings";
    
    [Required]
    public string ConnectionString { get; init; }

}