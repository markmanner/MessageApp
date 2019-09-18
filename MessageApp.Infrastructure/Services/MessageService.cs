using AutoMapper;
using MessageApp.Core.DTOs;
using MessageApp.Core.Entities;
using MessageApp.Core.Interfaces.Repositories;
using MessageApp.Core.Interfaces.Services;
using MessageApp.Infrastructure.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;

namespace MessageApp.Infrastructure.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHubContext<MessageHub> _hubContext;
        private readonly IMapper _mapper;

        public MessageService(IMessageRepository messageRepository, IUserRepository userRepository, IHubContext<MessageHub> hubContext, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
            _hubContext = hubContext;
            _mapper = mapper;
        }

        public void CreateMessage(string senderName, string senderId, string recipientId, string messageText)
        {
            CheckAvailableMessageSending(senderId);

            Message message = new Message()
            {
                MessageText = messageText,
                IsReadMessage = false,
                CreatedTime = DateTime.Now,
                RecipientId = recipientId,
                SenderId = senderId
            };

            _messageRepository.Add(message);
            _messageRepository.SaveChanges();

            SendMessage(senderName, recipientId, messageText);
        }

        public IList<IncomingMessageDTO> GetIncomingMessages(string recipientId)
        {
            IList<Message> incomingMessages = _messageRepository.GetIncomingMessage(recipientId);

            return _mapper.Map<IList<IncomingMessageDTO>>(incomingMessages);
        }

        private void CheckAvailableMessageSending(string userId)
        {
            if (!_userRepository.IsAvailableMessageSending(userId))
                throw new Exception("I am sorry, you can't send any more messages today");
        }

        private void SendMessage(string senderName, string recipientId, string messageText)
        {
            _hubContext.Clients.User(recipientId).SendAsync("NewMessage", senderName, messageText);
        }
    }
}
