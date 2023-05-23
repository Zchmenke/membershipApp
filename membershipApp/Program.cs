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
           Context DbContext= new Context();
           System runSys= new System();

           
            Console.WriteLine("Admin Login[1]");
            
            if (!int.TryParse(Console.ReadLine(), out int userInput))
            {
                Console.WriteLine("Wrong input, try again!");
                Console.ReadLine();
            }


            switch (userInput)
            {
                case 1:runSys.AdminLogin();
                    break;       
            }
           
        }

       
    }
}