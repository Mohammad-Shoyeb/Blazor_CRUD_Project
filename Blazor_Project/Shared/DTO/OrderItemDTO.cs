using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor_Project.Shared.DTO
{
    public class OrderItemDTO
    {
        [ForeignKey("Order")]
        public int OrderID { get; set; }
        [ForeignKey("MobilePhone")]
        public int MobilePhoneID { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}
