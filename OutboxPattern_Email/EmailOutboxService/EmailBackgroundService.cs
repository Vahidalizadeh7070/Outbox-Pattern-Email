using OutboxPattern_Email.EmailOutboxService.BackgroundServices;

namespace OutboxPattern_Email.EmailOutboxService
{
    public class EmailBackgroundService : BackgroundService
    {
        private readonly IEmailBackgroundServices _emailBackgroundServices;
        private readonly ILogger<EmailBackgroundService> _logger;

        public EmailBackgroundService(IEmailBackgroundServices emailBackgroundServices, ILogger<EmailBackgroundService> logger)
        {
            _emailBackgroundServices = emailBackgroundServices;
            _logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var timer = new System.Timers.Timer();
            timer.Interval = TimeSpan.FromMinutes(1).TotalMilliseconds;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }

        private async void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _logger.LogInformation("Messages are sending.");
            _emailBackgroundServices.Send();
            await Task.Yield();
        }
    }
}
