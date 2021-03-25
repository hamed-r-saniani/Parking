using ParkingML.Model;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace Parking
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ParkingManager manager = new ParkingManager();
            while (true)
            {
                Console.WriteLine("1.Add vehicle");
                Console.WriteLine("2.Remove vehicle");
                Console.WriteLine("3.Total Income");
                Console.WriteLine("4.Quit");
                Console.Write("Choose:");
                int choose = int.Parse(Console.ReadLine());
                if (choose == 1)
                {
                    char? add = null;
                    while (add != 'N')
                    {
                        Console.WriteLine("1.Car");
                        Console.WriteLine("2.Bike");
                        Console.Write("Choose (Enter 0 To Back):");
                        int addchoose = int.Parse(Console.ReadLine());
                        if (addchoose == 0)
                        {
                            add = 'N';
                            continue;
                        }
                        if (addchoose == 1)
                        {

                            Console.Write("Enter Time:");
                            int Enter = int.Parse(Console.ReadLine());
                            if (Enter < 1 || Enter > 24)
                            {
                                Console.WriteLine("Must Enter Number Between 1 & 24");
                                continue;
                            }
                            Car car = new Car()
                            {
                                EntryHour = Enter,
                                Type = Vehicle.VehicleType.Car
                            };
                            manager.AddVehicle(car);
                        }
                        else if (addchoose == 2)
                        {

                            Console.Write("Enter Time:");
                            int Enter = int.Parse(Console.ReadLine());
                            if (Enter < 1 || Enter > 24)
                            {
                                Console.WriteLine("Must Enter Number Between 1 & 24");
                                continue;
                            }
                            Bike bike = new Bike()
                            {
                                EntryHour = Enter,
                                Type = Vehicle.VehicleType.Bike
                            };
                            manager.AddVehicle(bike);
                        }
                        Console.Write("Do yo Want Continue? Y/N : ");
                        add = char.Parse(Console.ReadLine().ToUpper());
                    }
                }
                else if (choose == 2)
                {
                    char? remove = null;
                    while (remove != 'N')
                    {
                        Console.Write("Enter Id To Delete (Enter 0 To Cancel): ");
                        string id = Console.ReadLine();
                        if (id == "0")
                        {
                            continue;
                        }
                        Console.Write("Enter Exit Time To Delete (Enter 0 To Cancel): ");
                        int exit = int.Parse(Console.ReadLine());
                        if (exit == 0)
                        {
                            continue;
                        }

                        manager.RemoveVehicle(id, exit);
                        if (manager.result == 0)
                        {
                            Console.WriteLine("Your ID Not Found :(");
                        }
                        manager.result = 0;
                        Console.Write("Do yo Want Continue? Y/N : ");
                        remove = char.Parse(Console.ReadLine().ToUpper());
                    }

                }
                else if (choose == 3)
                {
                    manager.GetTotal();
                    manager.res = 0;
                }
                else if (choose == 4)
                {
                    Environment.Exit(0);
                }
                else
                {

                }
            }







            #region
            //Console.WriteLine(Guid.NewGuid().ToString());
            //Car car = new Car()
            //{
            //    Type = Vehicle.VehicleType.Car,
            //    EntryHour = 12
            //};


            //ParkingManager parking = new ParkingManager();

            //parking.AddVehicle(car);
            #endregion
            Console.ReadKey();
        }
    }
}
