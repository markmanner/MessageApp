using MessageApp.Core.Entities;
using MessageApp.Core.Interfaces.Repositories;
using MessageApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MessageApp.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly int MessageLimitPerDay = 5;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IList<ApplicationUser> GetAllRegisteredUser()
        {
            return _context.Users.ToList();
        }

        public int GetNumberOfAvailableMessages(string userId)
        {
            var sentMessageCount = _context.Messages
                .Where(w => w.SenderId == userId && w.CreatedTime.ToShortDateString() == DateTime.Now.ToShortDateString())
                .Count();

            return MessageLimitPerDay-sentMessageCount;
        }

        public bool IsAvailableMessageSending(string userId)
        {
            return _context.Messages
                .Where(w => w.SenderId == userId && w.CreatedTime.ToShortDateString() == DateTime.Now.ToShortDateString())
                .Count() < MessageLimitPerDay;
        }
    }
}
