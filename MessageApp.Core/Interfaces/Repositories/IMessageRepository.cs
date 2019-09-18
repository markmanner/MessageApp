using MessageApp.Core.DTOs;
using MessageApp.Core.Entities;
using System.Collections.Generic;

namespace MessageApp.Core.Interfaces.Repositories
{
    public interface IMessageRepository
    {
        Message Add(Message message);

        IList<Message> GetIncomingMessage(string userId);

        void SaveChanges();
    }
}
