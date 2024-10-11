namespace APIResiliente
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddHttpClient("resiliente")
                .AddStandardResilienceHandler(o =>
                {
                    o.Retry.MaxRetryAttempts = 3;
                });

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
