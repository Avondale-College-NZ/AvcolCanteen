using AvcolCanteen.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;

namespace AvcolCanteen.Controllers
{
    public class HomeController : Controller
    {
        //Global Declarations
        string mailBody = "<! DOCTYPE html>" +
"<html> " +
"<body style=\"background -color:#ff7f26;text-align:center; \"> " +
"<h1 style=\"color:#051a80;\">Welcome to Muhammad World</h1> " +
"<h2 style=\"color:#fff; \">Please find the attached files .< /h2> " +
"<label style=\"color:orange; font-size:100px; border: 5px dotted;>" +
"</body> " +
"</html>";

        string fromEmail = "tpi2024project@outlook.com";
        string mailTitle = "Attachment Demo";
        string mailSubject = "Email With Attachment";
        string mailPassword = "AvcolCanteen12345";


        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string toEmail, IFormFile fileToAttach)
        {
            //Mail message
            MailMessage message = new MailMessage(new MailAddress(fromEmail, mailTitle), new MailAddress(toEmail));

            //Mail content
            message.Subject = mailSubject;
            message.Body = mailBody;
            message.IsBodyHtml = true;

            //Attachment
            message.Attachments.Add(new Attachment(fileToAttach.OpenReadStream(), fileToAttach.FileName));

            //Server details
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp-mail.outlook.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            //Credentials
            System.Net.NetworkCredential credential = new System.Net.NetworkCredential();
            credential.UserName = fromEmail;
            credential.Password = mailPassword;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = credential;

            //SendEmail
            smtp.Send(message);

            ViewBag.emailsentmessage = "Email Sent Successfully";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Menupage()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
