using ExemploWorker.Services;

namespace ExemploWorker.Workers
{
    public class TimerWorker : IHostedService
    {
        private readonly ILogger<TimerWorker> _logger;
        private Timer? _timer;
        private readonly ISendEmail _sendEmail; // enviar email

        public TimerWorker(ILogger<TimerWorker> logger, IServiceProvider service)
        {
            _logger = logger;
            var scope = service.CreateScope().ServiceProvider; // criar escopo para injeção de dependência
            _sendEmail = scope.GetRequiredService<ISendEmail>(); // enviar email
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Iniciando o Timer Worker.");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            return Task.CompletedTask;
        }
        private void DoWork(object? state)
        {
            _logger.LogInformation("Tempo contando: {time}", DateTimeOffset.Now);
            _sendEmail.Enviar(); // enviar email
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Parando o Timer Worker.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
