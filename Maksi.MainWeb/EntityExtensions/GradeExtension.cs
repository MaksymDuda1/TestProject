using Maksi.Core.Models;
using Maksi.MainWeb.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Maksi.MainWeb.EntityExtensions;

public static class GradeExtension
{
    public static GradeDto ToDto(this Grade source)
    {
        return new GradeDto()
        {
            Id = source.Id,
            Name = source.Name
        };
    }
}