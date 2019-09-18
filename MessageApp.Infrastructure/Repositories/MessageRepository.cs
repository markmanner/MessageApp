using System.Collections.Generic;
using System.Linq;
using MessageApp.Core.Entities;
using MessageApp.Core.Interfaces.Repositories;
using MessageApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MessageApp.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;
        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Message Add(Message message)
        {
            _context.Messages.Add(message);

            return message;
        }

        public IList<Message> GetIncomingMessage(string userId)
        {
            return _context.Messages.Include(m=>m.Sender).Where(w => w.RecipientId == userId).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
