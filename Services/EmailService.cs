using System.Text.Json;
using Microsoft.Extensions.Logging;
using Resend;

namespace TyskaForSmaUpptackare.Services
{
    public class EmailService
    {
        private readonly IResend _resend;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IResend resend, ILogger<EmailService> logger)
        {
            _resend = resend;
            _logger = logger;
        }

        public async Task<bool> SendEmailAsync(string to, string subject, string htmlContent)
        {
            var message = new EmailMessage
            {
                From = "k.ekenberg.dev@karinwebdesigner.com",
                To = { to },
                Subject = subject,
                HtmlBody = htmlContent
            };

            try
            {
                var result = await _resend.EmailSendAsync(message);

                if (result != null)
                {
                    _logger.LogInformation("Mejl skickat! Resend-svar: {Response}", JsonSerializer.Serialize(result));
                    return true;
                }
                else
                {
                    _logger.LogWarning("Mejl skickades, men svaret från Resend var null.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fel vid Resend API-anrop.");
                return false;
            }
        }
    }
}
