using MessageApp.Core.Entities;
using System.Collections.Generic;

namespace MessageApp.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        IList<ApplicationUser> GetAllRegisteredUser();

        bool IsAvailableMessageSending(string userId);

        int GetNumberOfAvailableMessages(string userId);
    }
}
