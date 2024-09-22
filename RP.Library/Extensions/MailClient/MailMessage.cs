using MimeKit;

namespace RP.Library.Extensions.MailClient
{
    public class MailMessage()
    {
        public List<MailboxAddress> From { get; set; } = [];
        public List<MailboxAddress> To { get; set; } = [];
        public List<MailboxAddress> Cc { get; set; } = [];
        public List<MailboxAddress> Bcc { get; set; } = [];
        public string Subject { get; set; }
        public string Content { get; set; }
    }

    public class EmailAddress
    {
        public string Address { get; set; }
        public string DisplayName { get; set; }
    }
}
