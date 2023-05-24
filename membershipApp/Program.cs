using membershipApp.models;

namespace membershipApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
        }
        public static void Run()
        {
            var employees = new List<Employee>();
            Context DbContext = new Context();
            Systemhandler runSys = new Systemhandler();
            runSys.AdminLogin(employees);



        }


    }
}