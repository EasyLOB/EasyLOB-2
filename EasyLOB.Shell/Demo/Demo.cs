using System;

namespace EasyLOB.Shell
{
    partial class Program
    {
        private static void Demo()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Demo\n");
                Console.WriteLine("<0> RETURN");
                Console.WriteLine("<1> CodeSmith Demo");
                Console.WriteLine("<2> DIManager Demo");
                Console.WriteLine("<3> e-mail Demo");
                Console.WriteLine("<4> Multi-Tenant Demo");
                Console.WriteLine("<5> NLog Demo");
                Console.WriteLine("<6> Web Demo");
                Console.Write("\nChoose an option... ");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        CodeSmithDemo();
                        break;

                    case ('2'):
                        DIManagerDemo();
                        break;

                    case ('3'):
                        EMailDemo();
                        break;

                    case ('4'):
                        MultiTenantDemo();
                        break;

                    case ('5'):
                        NLogDemo();
                        break;

                    case ('6'):
                        WebDemo();
                        break;
                }

                if (!exit)
                {
                    Console.Write("\nPress <KEY> to continue... ");
                    Console.ReadKey();
                }
            }
        }
    }
}