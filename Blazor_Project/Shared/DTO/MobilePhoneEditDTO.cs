using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Blazor_Project.Shared.DTO
{
    public class MobilePhoneEditDTO
    {
        public int MobilePhoneID { get; set; }
        [Required, StringLength(50), Display(Name = "MobilePhone Name")]
        public string MobilePhoneName { get; set; } = default!;
        [Required, DataType(DataType.Currency), DisplayFormat(DataFormatString = "{0:0.00}")]
        public decimal Price { get; set; }
        [StringLength(150)]
        public string Picture { get; set; } = default!;
        public bool IsAvailable { get; set; }

    }
}
