using TuseAwesomeApiWeb.Dtos;
using TuseAwesomeApiWeb.Models;

namespace TuseAwesomeApiWeb.Extentions
{
    public static class ExtentionMethod
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                DateCreated = item.DateCreated
            };
        }

        public static UserDto AsUserDto(this User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                Email = user.Password
            };
        }
    }
}
