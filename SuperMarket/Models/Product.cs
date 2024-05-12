using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models
{
    public class Product
    {
        public int Id { get; set; }

        public int? ProducerId { get; set; }

        public int? CategoryId { get; set; }

        public string Barcode { get; set; }

        public Category Category { get; set; }

        public Producer Producer { get; set; }

        List<Stock> Stocks { get; set; } 

    }
}
