using ExemploWorker.Services;

namespace ExemploWorker.Workers
{
    public class TimerWorker : IHostedService
    {
        private readonly ILogger<TimerWorker> _logger;
        private Timer? _timer;
        private readonly IServiceProvider _serviceProvider;

        public TimerWorker(ILogger<TimerWorker> logger, IServiceProvider service)
        {
            _logger = logger;
            _serviceProvider = service;
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

            using var scope = _serviceProvider.CreateScope(); // criar escopo para injeção de dependência
            var sendEmail = scope.ServiceProvider.GetRequiredService<ISendEmail>();  
            sendEmail.Enviar(); // enviar email
        }
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Parando o Timer Worker.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
    }
}
