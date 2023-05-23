using membershipApp.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace membershipApp
{
    public class System
    {
        Context dbContext = new Context();
        public void AdminLogin()
        {
           
            List<Employee> employees = dbContext.Employees.ToList();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\tEnter Admin Username");
                string adminUsername = Console.ReadLine();
                Console.WriteLine("\tEnter Your Admin Password");
                string adminPassword = Console.ReadLine();

                if (employees.Contains(employees.Find(e => e.FullName == adminUsername))
                    && employees.Contains(employees.Find(e => e.Password == adminPassword)))
                {
                    AdminUi();
                }
                else
                {
                    Console.WriteLine($"\tLogin name or password was incorrect. you have {2 - i} tries left. ");
                    Console.ReadKey();
                    Console.Clear();
                }

            }

            Console.WriteLine("\tFailed three times, Closing program");
           

          
           

        }
        public void RegisterEmployee()
        {
            


            Console.WriteLine("\tInput Full name");
            string fullName = Console.ReadLine();
            Console.WriteLine("\tAdress");
            string adress = Console.ReadLine();
            Console.WriteLine("\tPhonenumber");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("\tSalary");
            string salary = Console.ReadLine();
            Console.WriteLine("\tPassword");
            string password = Console.ReadLine();

            Employee employeeHolder = new Employee();
            employeeHolder.FullName = fullName;
            employeeHolder.Adress = adress;
            employeeHolder.PhoneNumber = phoneNumber;
            employeeHolder.Salary = salary;
            employeeHolder.IsWorking = false;
            employeeHolder.Password = password;

            dbContext.Employees.Add(employeeHolder);
            dbContext.SaveChanges();


        }
        public void RegCustomerForThreeMonths()
        {
            


            Console.WriteLine("Input Full name");
            string fullName = Console.ReadLine();

            Console.WriteLine("Adress");
            string adress = Console.ReadLine();

            Console.WriteLine("Phonenumber");
            string phoneNumber = Console.ReadLine();

            Customer CustomerHolder = new Customer();
            CustomerHolder.FullName = fullName;
            CustomerHolder.Adress = adress;
            CustomerHolder.PhoneNumber = phoneNumber;
            CustomerHolder.ExpiryDate = DateTime.Now.AddMonths(3);
            CustomerHolder.IsExpired = false;
            CustomerHolder.IsTraining = false;

            dbContext.Customers.Add(CustomerHolder);
            dbContext.SaveChanges();

        }
        public void GymEnter()
        {
           
            var tempList = dbContext.Customers.ToList();


            Console.WriteLine("Insert your ID to enter");

            int memberShipId = Convert.ToInt32(Console.ReadLine());

            var tempCustomer = dbContext.Customers.Where
                (c => c.ID == memberShipId).FirstOrDefault();

            if (tempList.Contains
                (tempList.Find(c => c.ID == memberShipId)))
            {
                Console.WriteLine($" Welcome {tempCustomer.FullName}");
                tempCustomer.IsTraining = true;
                dbContext.SaveChanges();


            }


        }
        public void GymLeave()
        {
            
            var tempList = dbContext.Customers.ToList();


            Console.WriteLine("Insert your ID to Exit");

            int memberShipId = Convert.ToInt32(Console.ReadLine());

            var tempCustomer = dbContext.Customers.Where
                (c => c.ID == memberShipId).FirstOrDefault();

            if (tempList.Contains
                (tempList.Find(c => c.ID == memberShipId)))
            {
                Console.WriteLine($" Come back soon {tempCustomer.FullName}");
                tempCustomer.IsTraining = false;
                dbContext.SaveChanges();

            }


        }
        public void AdminUi()
        {
            Console.WriteLine("Hello from ADMIN UI");
            int userchoice = Convert.ToInt32(Console.ReadLine());
           
            switch (userchoice)
            {
                
                case 1: RegisterEmployee();
                    break;
                 case 2:RegCustomerForThreeMonths();
                    break;
           

                
            }
        }
    }
}
