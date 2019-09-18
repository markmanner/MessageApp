using AutoMapper;
using MessageApp.Core.DTOs;
using MessageApp.Core.Interfaces.Services;
using MessageApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Security.Claims;

namespace MessageApp.Web.Controllers
{
    public class MessageController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;
        public MessageController(IUserService userService, IMessageService messageService, IMapper mapper)
        {
            _userService = userService;
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult IncomingMessage()
        {
            IEnumerable<IncomingMessageViewModel> incomingMessageViewModels = 
                _mapper.Map<IEnumerable<IncomingMessageViewModel>>(_messageService.GetIncomingMessages(GetCurrentUserId()));

            return View(incomingMessageViewModels);
        }

        [HttpGet]
        public IActionResult SendMessage(string recipientId)
        {
            SendMessageViewModel sendMessageViewModel = InitSendMessageViewModel(recipientId);

            return View(sendMessageViewModel);
        }

        [HttpPost]
        public IActionResult SendMessage(SendMessageViewModel sendMessageViewModel)
        {
            if (!ModelState.IsValid)
            {
                sendMessageViewModel = InitSendMessageViewModel(sendMessageViewModel.RecipientId);

                return View(sendMessageViewModel);
            }

            _messageService.CreateMessage(GetCurrentUserName(), GetCurrentUserId(), sendMessageViewModel.RecipientId, sendMessageViewModel.MessageText);

            return RedirectToAction("Index", "User");
        }

        private SendMessageViewModel InitSendMessageViewModel(string recipientId)
        {
            IEnumerable<UserListViewModel> userListViewModels = _mapper.Map<IEnumerable<UserListViewModel>>(_userService.GetAllRegisteredUser());

            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            SendMessageViewModel sendMessageViewModel = new SendMessageViewModel()
            {
                Users = new SelectList(userListViewModels, "Id", "UserName", recipientId),
                IsAvailableMessageSending = _userService.IsAvailableMessageSending(userId)
            };

            return sendMessageViewModel;
        }

        private string GetCurrentUserId()
        {
            return this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private string GetCurrentUserName()
        {
            return this.User.Identity.Name;
        }
    }
}