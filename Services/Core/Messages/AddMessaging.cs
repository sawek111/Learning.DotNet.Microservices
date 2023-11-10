using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Core.Messages;

public static class Installer
{
    /// <summary>
    /// Requires additional configuration declared in RabbitSettings
    /// </summary>
    public static void AddMessagingInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddOptions<RabbitSettings>()
            .BindConfiguration(RabbitSettings.SectionName)
            .ValidateDataAnnotations();
        services.AddSingleton(sp => sp.GetRequiredService<IOptions<RabbitSettings>>().Value);
        var settings = configuration.GetSection(RabbitSettings.SectionName).Get<RabbitSettings>();

        services.AddMassTransit(config => {

            config.SetKebabCaseEndpointNameFormatter();

            config.UsingRabbitMq((ctx, cfg) => {
                cfg.Host($"rabbitmq://{settings!.ConnectionString}", h => {
                    h.Username(settings.Host);
                    h.Password(settings.Password);
                });

                cfg.ConfigureEndpoints(ctx);
            });
        });
    }
}