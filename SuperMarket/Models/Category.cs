using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models
{
    public class Category
    {
        public int Id { get; set; } 

        public string CategoryName { get; set; }

        List<Product> Products { get; set; }
    }
}
