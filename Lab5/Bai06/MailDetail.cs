namespace Bai06
{
    public class MailDetail
    {
        public string? FromName { get; set; }
        public string? FromAddress { get; set; }
        public string? ToName { get; set; }
        public string? ToAddress { get; set; }

        public string? Subject { get; set; }
        public string? Date { get; set; }
        public string? BodyText { get; set; }
        public string? BodyHtml { get; set; }

        public List<MailAttachment> Attachments { get; set; } = new();
    }

}
