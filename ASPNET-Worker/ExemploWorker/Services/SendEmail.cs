namespace ExemploWorker.Services
{
    public class SendEmail : ISendEmail
    {
        private readonly ILogger<SendEmail> _logger;
        public SendEmail(ILogger<SendEmail> logger)
        {
            _logger = logger;
        }
        public void Enviar()
        {
            _logger.LogInformation("E-mail enviado com sucesso!");
        }
    }
}
