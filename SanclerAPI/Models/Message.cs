using System.Collections.Generic;
using System.Linq;
using MimeKit;

namespace SanclerAPI.Models
{
    public class Message
    {
        public List<MailboxAddress> Addresse { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public Message(IEnumerable<string> Addresse, 
                       string Subject, 
                       string UserId, 
                       string code)
        {
            this.Addresse = new List<MailboxAddress>();
            this.Addresse.AddRange(Addresse.Select(d => new MailboxAddress(d, d)));
            this.Subject = Subject;
            this.Content = $"https://localhost:5001/api/v1/Autorization/Confirm?UserId={UserId}&AcctivationCode={code}";
        }
        public Message(string[] addresse, string subject, string content)
        {
            this.Addresse = new List<MailboxAddress>();
            this.Addresse.AddRange(addresse.Select(d => new MailboxAddress(d, d)));
            Subject = subject;
            Content = content;
        }
    }
}