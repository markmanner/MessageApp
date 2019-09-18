using System;
using System.Collections.Generic;
using System.Text;

namespace MessageApp.Core.DTOs
{
    public class NewMessageDTO
    {
        public string MessageText { get; set; }

        public string SenderId { get; set; }

        public string RecipientId { get; set; }
    }
}
