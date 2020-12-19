﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;

            string address = "net.tcp://localhost:9999/WCFServer";


            using (WCFClient proxy = new WCFClient(binding, address))
            {
                Menu(proxy);
            }

            Console.ReadLine();

        }

        public static void Menu(WCFClient proxy)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Client started by : " + WindowsIdentity.GetCurrent().Name);
                Console.WriteLine("Choose option: ");
                Console.WriteLine("-----------------------");
                Console.WriteLine("1. Get bill.");
                Console.WriteLine("2. Modify ID (only for operators)");
                Console.WriteLine("3. Modify value (only for operators)");
                Console.WriteLine("4. Add entity (only for administrators)");
                Console.WriteLine("5. Delete entity (only for administrators)");
                Console.WriteLine("6. Delete database (only for super-administrators)");
                Console.WriteLine("7. Archive database (only for super-administrators)");


                int choice = 0;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }


                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Not implemented yet");

                        break;
                    case 2:
                        //Console.WriteLine("Not implemented yet");
                        Console.WriteLine("Enter old ID: ");

                        long oldId = 0;

                        if (long.TryParse(Console.ReadLine(), out oldId))
                        {
                            Console.Write("Enter new ID: ");

                            long newId = 0;

                            if (long.TryParse(Console.ReadLine(), out newId))
                            {
                                //proxy.ModifyID(oldId, newId);
                            }
                            else
                            {
                                Console.WriteLine("Invalid input!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");

                        }
                        break;
                    case 3:     // change value 
                        Console.Write("Enter ID: ");
                        long i;
                        double value;
                        if (long.TryParse(Console.ReadLine(), out i))
                        {
                            Console.Write("Enter new value: ");
                            if (double.TryParse(Console.ReadLine(), out value))
                            {
                                //proxy.ModifyValue(i, value);
                            }
                            else
                            {
                                Console.WriteLine("Invalid value!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        break;
                    case 4:     // add new entity to db
                        //Console.WriteLine("Not implemented yet");
                        Console.Write("Enter ID: ");
                        long id;
                        double v;
                        if (long.TryParse(Console.ReadLine(), out id))
                        {
                            Console.Write("Enter value: ");
                            if (double.TryParse(Console.ReadLine(), out v))
                            {
                                // proxy.ModifyValue(id, v);
                            }
                            else
                            {
                                Console.WriteLine("Invalid value!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        break;
                    case 5:
                        //Console.WriteLine("Not implemented yet");
                        Console.Write("Enter ID to delete: ");
                        long del_id;
                        if (long.TryParse(Console.ReadLine(), out del_id))
                        {
                            //proxy.DeleteEntity(del_id);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        break;
                    case 6:
                        //Console.WriteLine("Not implemented yet");
                        //proxy.DeleteDatabase();
                        break;
                    case 7:
                        Console.WriteLine("Not implemented yet");
                        break;
                    default:
                        break;
                }
                Console.Write("Press enter to continue...");
                Console.ReadLine();
            }
        }
    }
}
