namespace AvcolCanteen.RazorPage.Settings
{
    public class SendGridSettings
    {
        // Property to store the email address from which emails will be sent
        public string FromEmail { get; set; }

        // Property to store the name associated with the email address
        public string EmailName { get; set; }

        // Property to store the API key for authenticating with SendGrid
        public string ApiKey { get; set; }
    }
}
