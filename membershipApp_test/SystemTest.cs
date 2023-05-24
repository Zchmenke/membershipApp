using membershipApp.models;
using membershipApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore.Metadata;

namespace membershipApp_test
{
    [TestClass]
    public class SystemTest
    {


        [TestMethod]
        public void Gym_Enter_Should_Return_Welcome_Message()
        {
            // Arrange
            //make a fake "database" of customers so i can try the function 
            var customers = new List<Customer>();
            // Add fake customers to the list
            customers.Add(new Customer { ID = 1, FullName = "Henrik Rydén", IsTraining = false, IsExpired = false });
            customers.Add(new Customer { ID = 2, FullName = "Simon Grenefalk", IsTraining = false, IsExpired = false });


            // Create a StringWriter to capture the console output
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Arrange 
            int membershipId = 2;
            string expectedMessage = "Welcome Simon Grenefalk";

            // Act
            using (StringReader reader = new StringReader(membershipId.ToString())) // added stringReaders so i can simulate console.Readlines()
            {
                Console.SetIn(reader);

                Systemhandler sys = new Systemhandler();
                sys.GymEnter(customers);
            }

            // Assert
            Customer customer = customers
                .FirstOrDefault(c => c.ID == membershipId);
            Assert.IsTrue(customer.IsTraining); // checking if the bool is properly set to true - meaning the customer is "checked in"
            StringAssert.Contains(consoleOutput.ToString(), expectedMessage); // checking that the output is correct.
        }


        // testing so that the fail message displays properly
        [TestMethod]
        public void Gym_Enter_Fail_should_Return_Return_Message()
        {
            // Arrange
            var customers = new List<Customer>();

            // Add fake customers to the list
            customers.Add(new Customer { ID = 1, FullName = "Henrik Rydén" });
            customers.Add(new Customer { ID = 2, FullName = "Simon Grenefalk" });

            // Create a StringWriter to capture the console output
            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            // Arrange 
            int membershipId = 10;
            string expectedMessage = "There is no viable ID";

            // Act
            using (StringReader reader = new StringReader(membershipId.ToString())) // added stringReaders so i can simulate console.Readlines()
            {
                Console.SetIn(reader);

                Systemhandler sys = new Systemhandler();
                sys.GymEnter(customers);
            }

            // Assert

            StringAssert.Contains(consoleOutput.ToString(), expectedMessage);
            Customer customer = customers
               .FirstOrDefault(c => c.ID == membershipId);
            Assert.IsNull(customer); // Making sure nothing was added or changed since the functiuon "Failed"

        }




        
        ////////////////////////////////(  Admin Log In  )//////////////////////////////////////////////
        
        [TestMethod]
        public void Admin_Should_Log_In_If_UserName_And_Password_Is_Correct()
        {
            // Arrange 
            // Makes a new list with an Admin in it.
            var employees = new List<Employee>();
            employees.Add(new Employee { FullName = "Admin", Password = "Admin123" });

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            var expectedOutput = "Welcome Admin, Choose action";

            // Act
            using (StringReader reader = new StringReader("Admin\nAdmin123"))// added stringReaders so i can simulate console.Readlines()
            {
                Console.SetIn(reader);

                Systemhandler sys = new Systemhandler();
                sys.AdminLogin(employees);
            }

            // Assert
            StringAssert.Contains(consoleOutput.ToString(), expectedOutput);


        }

        [TestMethod]
        public void Admin_UserName_Or_Password_WasIncorrect_Return_ErrorMessage()
        {
            //Arrange
            var employees = new List<Employee>();
            employees.Add(new Employee { FullName = "Admin", Password = "Admin123" });

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            var expectedOutput = "Login name or password was incorrect.";

            //Act
            using (StringReader reader = new StringReader("Wrong\nInput")) // added wrong input so i can teest the other outcomes.
            {
                Console.SetIn(reader);
                Systemhandler sys = new Systemhandler();
                sys.AdminLogin(employees);
            }
            //Assert
            StringAssert.Contains(consoleOutput.ToString(), expectedOutput);

        }

        [TestMethod]
        public void Admin_Failed_Three_Times_Closes_Application()
        {
            // Arrange
            var employees = new List<Employee>();
            employees.Add(new Employee { FullName = "Admin", Password = "Admin123" });

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            var expectedOutput = "\tFailed three times, Closing program";

            // Act 
            using (StringReader reader = new StringReader("Wrong\nInput\nWrong\nInput\nWrong\nInput\n"))// added stringReaders so i can simulate console.Readlines()
            {
                Console.SetIn(reader);

                Systemhandler sys = new Systemhandler();
                sys.AdminLogin(employees);
            }


            StringAssert.Contains(consoleOutput.ToString().Trim(), expectedOutput);


        }
    }
}




