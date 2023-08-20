namespace BtkAkademi.Service.MessageAPI.Models
{
    public class MessageDto
    {
        public string ConversationId { get; set; }
        public string? MessageContent { get; set; }
        public string? ClientConnectionId { get; set; }
        public bool IsAdmin { get; set; }
    }
}
