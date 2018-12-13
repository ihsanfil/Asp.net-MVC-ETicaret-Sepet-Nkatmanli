using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;


namespace Northwind.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "isim girilmesi zorunludur")]
        [Display(Name = "Ad Soyad")]
        public string Name { get; set; }

        [Required(), StringLength(50,MinimumLength = 10)]
        public string Address1 { get; set; }

        [StringLength(50)]
        public string Address2 { get; set; }

        [StringLength(50)]
        public string Address3 { get; set; }

        [Required()]
        public string City { get; set; }
    
        public string Country { get; set; }

        
        public bool IsGift { get; set; } //hediye olacak mı 

    }
}