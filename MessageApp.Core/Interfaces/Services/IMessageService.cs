using MessageApp.Core.DTOs;
using System.Collections.Generic;

namespace MessageApp.Core.Interfaces.Services
{
    public interface IMessageService
    {
        void CreateMessage(string senderName, string senderId, string recipientId, string messageText);

        IList<IncomingMessageDTO> GetIncomingMessages(string recipientId);
    }
}
