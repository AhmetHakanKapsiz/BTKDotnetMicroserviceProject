namespace BtkAkademi.Service.MessageAPI.Models
{
    public class AdminMessageDto
    {
        public string conversationId { get; set; }
        public string MessageContent { get; set; }
        public string? adminConnectionId { get; set; }
    }
}
