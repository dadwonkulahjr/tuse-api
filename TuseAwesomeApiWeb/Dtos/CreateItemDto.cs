using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TuseAwesomeApiWeb.Dtos
{
    public record CreateItemDto
    {
        [StringLength(50), Required]
        public string Name { get; init; }
        [DataType(DataType.Currency), Required, Column(TypeName = "decimal(18, 2)"), Range(1, 100)]
        public decimal Price { get; init; }
        [Required, Column(TypeName = "date")]
        public DateTime? DateCreated { get; init; }
    }
}
