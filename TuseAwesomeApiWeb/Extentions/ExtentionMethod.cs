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
    }
}
