namespace BtkAkademi.Web.Models
{
    public class Message
    {
        public int Id { get; set; }
        public Guid ConversationId { get; set; }
        public string MessageContent { get; set; }
        public string clientConnectionId { get; set; }
        public string? adminConnectionId { get; set; }
        public DateTime dateTime { get; set; }
    }
}
