using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHDDManagerClass
{
    public class PaymentCollected
    {
        public int AssociateID { get; set; }
        public string AssociateName { get; set; }
        public decimal TotalCollected { get; set; }

        public PaymentCollected(int associateID, string associateName, decimal totalCollected)
        {
            AssociateID = associateID;
            AssociateName = associateName;
            TotalCollected = totalCollected;
        }
    }


}
