using Coravel;
using Coravel.Queuing.Interfaces;
using Coravel.Scheduling.Schedule.Interfaces;
using Coravel.Webapi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScheduler();
builder.Services.AddQueue();
builder.Services.AddTransient<RepeatableTask>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet(
        "/example", (IScheduler scheduler, IQueue queue) =>
        {
            scheduler.Schedule<RepeatableTask>()
                .EverySeconds(2);

            queue.QueueTask(async () => await Task.Delay(1));
            queue.QueueTask(
                async () =>
                {
                    await Task.Delay(2);
                    Console.WriteLine("2nd queue task running!");
                });
        })
    .WithName("ScheduleExample")
    .WithOpenApi();


app.Run();