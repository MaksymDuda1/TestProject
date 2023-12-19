using Maksi.Core.Models;
using Maksi.MainWeb.Dtos;

namespace Maksi.MainWeb.EntityExtensions;

public static class UserExtension
{
    public static UserDto ToDto(this User source)
    {
        return new UserDto()
        {
            Email = source.Email,
            Password = source.Password
        };
    }
}