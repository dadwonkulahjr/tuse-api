using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TuseAwesomeApiWeb.Models
{
    public record Item
    {
        public Guid Id { get; init; }
        [StringLength(50), Required]
        public string Name { get; init; }
        [DataType(DataType.Currency),Required, Column(TypeName ="decimal(18, 2)")]
        public decimal Price { get; init; }
        [Required, Column(TypeName ="date")]
        public DateTime? DateCreated { get; init; }

    }
}
