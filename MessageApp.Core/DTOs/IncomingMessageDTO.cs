using System;

namespace MessageApp.Core.DTOs
{
    public class IncomingMessageDTO
    {
        public Guid Id { get; set; }

        public string MessageText { get; set; }

        public bool IsReadMessage { get; set; }

        public DateTime CreatedTime { get; set; }

        public string SenderName { get; set; }
    }
}
