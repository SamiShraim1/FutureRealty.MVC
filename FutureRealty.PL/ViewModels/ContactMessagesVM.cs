namespace FutureRealty.PL.Models
{
    public class ContactMessagesVM
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime? SentAt { get; set; }
        public bool InWork { get; set; }
    }
}
