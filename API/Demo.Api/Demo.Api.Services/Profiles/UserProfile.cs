using System;
using AutoMapper;

namespace Demo.Api.Services.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Demo.Api.Data.User, Demo.Api.Models.User>().ReverseMap();
        }
    }
}
