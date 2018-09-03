using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace EasyLOB.Shell
{
    partial class Program
    {
        static void Main(string[] args)
        {
            AppHelper.Setup();

            // EF 6.0 Log
            //DbInterception.Add(new NLogCommandInterceptor());

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("EasyLOB Shell\n");
                Console.WriteLine("<0> EXIT");
                Console.WriteLine("<1> Application Demo");
                Console.WriteLine("<2> Persistence Demo");
                Console.WriteLine("<3> EDM Demo");
                Console.WriteLine("<4> Demo");
                Console.Write("\nChoose an option... ");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        ApplicationDemo();
                        break;

                    case ('2'):
                        PersistenceDemo();
                        break;

                    case ('3'):
                        EDMDemo();
                        break;

                    case ('4'):
                        Demo();
                        break;
                }

                //if (!exit && "".IndexOf(key.KeyChar) >= 0)
                //{
                //    Console.Write("\nPress <KEY> to continue... ");
                //    Console.ReadKey();
                //}
            }
        }

        #region  Methods Write

        private static void Write(string s)
        {
            Console.WriteLine(s);
        }

        private static void WriteException(Exception exception)
        {
            Console.WriteLine(exception.Message, "");
        }

        private static void WriteException(Exception exception, string spaces)
        {
            Console.WriteLine(exception.Message);
            if (exception.InnerException != null)
            {
                WriteException(exception.InnerException, spaces + "  ");
            }
        }

        private static void WriteJSON(Object o)
        {
            string json = JsonConvert.SerializeObject(o, Formatting.Indented);
            Console.WriteLine(json);
        }

        private static void WriteObject(Object o)
        {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(o))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(o);
                if (name != "ExtensionData")
                {
                    Console.WriteLine("{0} = {1}", name, value);
                }
            }
        }

        private static void WriteOperationResult(ZOperationResult operationResult)
        {
            Console.WriteLine(operationResult.Text);
        }

        #endregion Methods Write
    }
}
