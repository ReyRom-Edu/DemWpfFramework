using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemWpfFramework21.Models
{
    partial class Product
    {
        public string PhotoPath => Path.Combine(Environment.CurrentDirectory, "Images",
            string.IsNullOrWhiteSpace(Photo) ? "picture.png" : Photo);

        public bool HasDiscount => Discount > 0;
        public bool IsBigDiscount => Discount > 15;

        public decimal DiscountedPrice => Price * (1 - Discount/100M); //Price * (100 - Discount)/100M
    }
}
