using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace membershipApp.models
{
    public class Employee
    {

        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Salary { get; set; }
        public bool IsWorking { get; set; }
        public string Password { get; set; }
    }
}
