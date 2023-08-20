namespace BtkAkademi.Web.Models
{
    public class Message
    {
        public int Id { get; set; }
        public Guid ConversationId { get; set; }
        public string MessageContent { get; set; }
        public string ClientConnectionId { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime dateTime { get; set; }
    }
}
