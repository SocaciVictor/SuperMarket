using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models
{
    public class Category
    {
   
        public int Id { get; set; } 

        public string CategoryName { get; set; }

        public bool IsActive { get; set; } = true;

        List<Product> Products { get; set; }
    }
}
