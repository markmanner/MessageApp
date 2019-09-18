using AutoMapper;
using MessageApp.Core.DTOs;
using MessageApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MessageApp.Infrastructure.MappingProfiles
{
    public class InfrastructureMappingProfile : Profile
    {
        public InfrastructureMappingProfile()
        {
            CreateMap<ApplicationUser, UserListDTO>();

            CreateMap<Message, IncomingMessageDTO>()
                .ForMember(dest => dest.SenderName, opt => opt.MapFrom(src => src.Sender.UserName));
        }
    }
}
