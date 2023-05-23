using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace membershipApp.models
{
    public class Customer
    {
        public int ID{ get; set; }
        public string FullName { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
       

        public DateTime ExpiryDate { get; set; }
        public bool IsExpired { get; set; }
        public bool IsTraining { get; set; }
    }
}
