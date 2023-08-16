namespace BtkAkademi.Service.MessageAPI.Models
{
    public class ClientMessage
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string clientConnectionId { get; set; }
    }
}
