using AutoMapper;
using MessageApp.Core.DTOs;
using MessageApp.Web.ViewModels;
using System;

namespace MessageApp.Web.MappingProfiles
{
    public class WebMappingProfile : Profile
    {
        public WebMappingProfile()
        {
            CreateMap<UserListDTO, UserListViewModel>().ReverseMap();
            CreateMap<IncomingMessageDTO, IncomingMessageViewModel>().ReverseMap();
        }
    }
}
