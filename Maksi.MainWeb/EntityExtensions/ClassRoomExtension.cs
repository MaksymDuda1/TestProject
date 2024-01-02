using Maksi.Core.Models;
using Maksi.MainWeb.Dtos;

namespace Maksi.MainWeb.EntityExtensions;

public static class ClassRoomExtension
{
    public static ClassRoomDto ToDto(this ClassRoom source)
    {
        return new ClassRoomDto()
        {
            Id = source.Id,
            Name = source.Name
        };
    }
}