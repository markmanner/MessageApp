using AutoMapper;
using MessageApp.Core.DTOs;
using MessageApp.Core.Entities;
using MessageApp.Core.Interfaces.Repositories;
using MessageApp.Core.Interfaces.Services;
using System.Collections.Generic;

namespace MessageApp.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public IList<UserListDTO> GetAllRegisteredUser()
        {
            IList<ApplicationUser> users = _userRepository.GetAllRegisteredUser();

            return _mapper.Map<IList<UserListDTO>>(users);
        }
        public bool IsAvailableMessageSending(string userId)
        {
            return _userRepository.IsAvailableMessageSending(userId);
        }
        
    }
}
