using Coravel.Invocable;
using Microsoft.Extensions.Logging;

namespace Coravel.Scheduler.ConsoleApp;

/// <summary>
/// Remember Coravel doesn't support persistence
/// </summary>
/// <param name="_logger"></param>
public class RepeatableTaskWithCustomParameter(ILogger<RepeatableTask> _logger, string myCustomParameter) : IInvocable
{
    public async Task Invoke()
    { 
        await Task.Delay(1);
        _logger.LogInformation($"Scheduled task running from own class with parameter: {myCustomParameter}");
    }
}