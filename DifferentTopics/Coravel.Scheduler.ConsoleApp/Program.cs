using Coravel;
using Coravel.Scheduler.ConsoleApp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = Host.CreateApplicationBuilder();
builder.Services.AddScheduler();
builder.Services.AddTransient<RepeatableTask>();
builder.Services.AddTransient<RepeatableTaskWithCustomParameter>();


var app = builder.Build();
app.Services.UseScheduler(
    scheduler =>
    {
        scheduler.ScheduleAsync(
            async () =>
            {
                await Task.Delay(1);
                Console.WriteLine("Scheduled task running from lambda!");
            }).EverySeconds(2);

        scheduler.Schedule<RepeatableTask>().EveryFiveSeconds();
        scheduler.ScheduleWithParams<RepeatableTaskWithCustomParameter>("MyParameter").EverySeconds(3);
    });

app.Run();