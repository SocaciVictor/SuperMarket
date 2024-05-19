using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models
{
    public class Stock
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public float Amount { get; set; }

        public string Unit { get; set; }

        public DateTime SupplyDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public float PurchasePrice { get; set; }

        public float SellingAmount { get; set; }

        public bool IsActive { get; set; } = true;

        public Product Product { get; set; }
    }
}
