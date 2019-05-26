using EasyLOB.Library.AspNet;
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
                Console.WriteLine("<1> DIManager Demo");
                Console.WriteLine("<2> e-mail Demo");
                Console.WriteLine("<3> Multi-Tenant Demo");
                Console.WriteLine("<4> Log Demo");
                Console.WriteLine("<5> Paths Demo");
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
                        DIManagerDemo();
                        break;

                    case ('2'):
                        EMailDemo();
                        break;

                    case ('3'):
                        MultiTenantDemo();
                        break;

                    case ('4'):
                        LogDemo();
                        break;

                    case ('5'):
                        PathsDemo();
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

        private static void PathsDemo()
        {
            string path = ConfigurationHelper.AppSettings<string>("EasyLOB.Directory.Configuration");
            Console.WriteLine("\nPaths Demo");
            Console.WriteLine("\nWebHelper.WebDirectory(path): {0}", WebHelper.WebDirectory(path));
            Console.WriteLine("WebHelper.IsWeb: {0}", WebHelper.IsWeb.ToString());
            Console.WriteLine("WebHelper.WebUrl: {0}", WebHelper.WebUrl);
            Console.WriteLine("WebHelper.WebPath: {0}", WebHelper.WebPath);
            Console.WriteLine("WebHelper.WebDomain: {0}", WebHelper.WebDomain);
            Console.WriteLine("WebHelper.WebSubDomain: {0}", WebHelper.WebSubDomain);
            Console.WriteLine("\nAppDomain.CurrentDomain.BaseDirectory: {0}", AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}