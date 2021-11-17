using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuseAwesomeApiWeb.Dtos
{
    public record ItemDto
    {
        public Guid Id { get; init; }
        [StringLength(50), Required]
        public string Name { get; init; }
        [DataType(DataType.Currency), Required, Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; init; }
        [Required, Column(TypeName = "date")]
        public DateTime? DateCreated { get; init; }
    }
}
