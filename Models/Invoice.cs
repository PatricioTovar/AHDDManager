using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AHDDManager.Models
{
    public class Invoice
    {
        public AHDDManagerClass.Customer Customer { get; set; }
        public AHDDManagerClass.Business Business { get; set; }
        public AHDDManagerClass.TransactionDetails TransactionDetails { get; set; }
        public AHDDManagerClass.Transaction Transaction { get; set; }
        public AHDDManagerClass.Payments Payments { get; set; }
        public AHDDManagerClass.Refunds Refunds { get; set; }
    }
}