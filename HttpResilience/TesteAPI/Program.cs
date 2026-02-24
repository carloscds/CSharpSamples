var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/", () => $"TesteAPI - {DateTime.Now}");
app.Run();
