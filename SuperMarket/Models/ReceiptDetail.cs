using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models
{
    public class ReceiptDetail
    {
        public int Id { get; set; } 

        public int ReceiptId { get; set; }

        public int IdProduct { get; set; }

        public float Amount { get; set; }

        public float Subtotal { get; set; }

        public Receipt Receipt { get; set; }

        public Product Product { get; set; }
    }
}
