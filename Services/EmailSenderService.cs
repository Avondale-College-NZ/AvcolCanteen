using AvcolCanteen.RazorPage.Settings;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;

namespace AvcolCanteen.RazorPage.Services;

public class EmailSenderService : IEmailSender
{
    // Assigning SendGrid settings and client

    private readonly ISendGridClient _sendGridClient;
    private readonly SendGridSettings _sendGridSettings;
    public EmailSenderService(ISendGridClient sendGridClient,
    IOptions<SendGridSettings> sendGridSettings)
    {
        _sendGridClient = sendGridClient;
        _sendGridSettings = sendGridSettings.Value;
    }

    // Method to send an email
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // Creating a new SendGrid message
        var msg = new SendGridMessage()
        {
            From = new EmailAddress(_sendGridSettings.FromEmail, _sendGridSettings.EmailName), // Setting the sender's email and name
            Subject = subject, // Setting the email subject
            HtmlContent = htmlMessage // Setting the HTML content of the email
        };
        msg.AddTo(email); // Adding the recipient's email address
        await _sendGridClient.SendEmailAsync(msg); // Sending the email
    }
}
