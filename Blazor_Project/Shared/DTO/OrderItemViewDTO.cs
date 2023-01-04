using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_Project.Shared.DTO
{
    public class OrderItemViewDTO
    {
        public int OrderID { get; set; }
        [Required]
        public string MobilePhoneName { get; set; } = default!;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}
