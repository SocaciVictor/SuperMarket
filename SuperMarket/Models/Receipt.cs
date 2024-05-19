using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Models
{
    public class Receipt
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime ReceiptDate { get; set; }

        public float ReceiptAmount { get; set; }
        
        public User User { get; set; }

        public bool IsActive { get; set; } = true;

        List<ReceiptDetail> ReceiptDetails { get; set; } 
    }
}
