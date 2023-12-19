using AutoMapper;
using Maksi.Core.Models;
using Maksi.MainWeb.Dtos;

namespace Maksi.MainWeb.Profiles;

public class UserProfile : Profile
{
   public UserProfile()
   {
       CreateMap<UserDto, User>();
   }
}