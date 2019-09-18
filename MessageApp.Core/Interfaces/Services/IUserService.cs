using MessageApp.Core.DTOs;
using System.Collections.Generic;

namespace MessageApp.Core.Interfaces.Services
{
    public interface IUserService
    {
        IList<UserListDTO> GetAllRegisteredUser();
        bool IsAvailableMessageSending(string userId);
    }
}
