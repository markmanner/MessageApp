using System.Collections.Generic;
using AutoMapper;
using MessageApp.Core.DTOs;
using MessageApp.Core.Interfaces.Services;
using MessageApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MessageApp.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            IList<UserListDTO> userListDTOs = _userService.GetAllRegisteredUser();

            IEnumerable<UserListViewModel> userListViewModels = _mapper.Map<IEnumerable<UserListViewModel>>(userListDTOs);

            return View(userListViewModels);
        }
    }
}