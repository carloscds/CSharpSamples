using ExemploWorker.Services;
using ExemploWorker.Workers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddHostedService<TimerWorker>();

builder.Services.AddScoped<ISendEmail, SendEmail>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapGet("/", () => "Exemplo de API com Worker");
app.Run();

