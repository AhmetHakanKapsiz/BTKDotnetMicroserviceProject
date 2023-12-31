﻿using System.ComponentModel.DataAnnotations;

namespace BtkAkademi.Service.MessageAPI.Models
{
    public class Message
    {
        public int Id { get; set; }
        public Guid ConversationId { get; set; }
        public string? MessageContent { get; set; }
        public string? ClientConnectionId { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime Datetime { get; set; }
    }
}
