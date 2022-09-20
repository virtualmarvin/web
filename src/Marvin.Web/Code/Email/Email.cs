using Marvin.Web.Domain;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Marvin.Web
{
    // Central email facility

    #region Interface

    public interface IEmail
    {
        void SendActivationMessage(User user);
        void SendResetMessage(User user);
    }

    #endregion

    public class Email : IEmail
    {
        #region Implementation

        private static readonly string FromEmail = "hello@company.com";

        public void SendActivationMessage(User user)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Hi " + user.FirstName + ",");
            sb.AppendLine();
            sb.AppendLine("We are sending you this email because your new account requires activation.");
            sb.AppendLine("Click the link below and you'll be asked to choose your password: ");
            sb.AppendLine();
            sb.AppendLine(@"http://localhost:44313/activate/" + user.ActivationCode);
            sb.AppendLine();
            sb.AppendLine("If clicking the link does not work, copy it into your browser command line. ");
            sb.AppendLine();

            sb.AppendLine("33-Day Starter");
            sb.AppendLine("www.dofactory.com");
            sb.AppendLine();

            var to = user.Email;
            var subject = "Dofactory Starter account activation";
            var body = sb.ToString();

            string from = FromEmail;

            Send(from, to, subject, body);
        }

        public void SendResetMessage(User user)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Hi " + user.FirstName + ",");
            sb.AppendLine();

            sb.AppendLine("We are sending you this email because you requested to reset your password.");
            sb.AppendLine("Click the link below and you'll be asked to choose a new password: ");
            sb.AppendLine();

            sb.AppendLine(@"http://localhost:44313/reset/" + user.ResetCode);

            sb.AppendLine();
            sb.AppendLine("If clicking the link does not work, copy it into your browser command line. ");
            sb.AppendLine();

            sb.AppendLine("33-Day Starter");
            sb.AppendLine("www.dofactory.com");
            sb.AppendLine();

            var to = user.Email;
            var subject = "Dofactory Starter password reset";
            var body = sb.ToString();

            string from = FromEmail;
            Send(from, to, subject, body);
        }

        private void Send(string from, string to, string subject, string body)
        {
            var client = new SmtpClient("mail.company.com");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("username", "password");

            var message = new MailMessage();

            message.From = new MailAddress(from);
            message.To.Add(to);

            message.Subject = subject;
            message.Body = body;

            // Uncomment in production
            //client.Send(message);
        }

        #endregion
    }
}
