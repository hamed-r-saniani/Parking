using ParkingML.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    public class ParkingManager
    {
        //Car car;
        //Bike bike;
        //object o;
        //public ParkingManager(object a)
        //{
        //    if (a is Car)
        //    {
        //        car = (Car)a;
        //    }
        //    else if (a is Bike)
        //    {
        //        bike = (Bike)a;
        //    }
        //    o = a;
        //}
        List<list> vehicles = new List<list>();
        List<int> total = new List<int>();
         public int res = 0;
        public int result = 0;


        public bool AddVehicle(object o)
        {
            if (o is Car)
            {
                Car car = (Car)o;
                list List;
                List.Type = car.Type.ToString();
                List.ID = car.ID;
                List.Enter = car.EntryHour;
                vehicles.Add(List);
                Console.WriteLine("Your CarID is:{0}", car.ID);
                return true;
            }
            else if (o is Bike)
            {
                Bike bike = (Bike)o;
                list List;
                List.Type = bike.Type.ToString();
                List.ID = bike.ID;
                List.Enter = bike.EntryHour;
                vehicles.Add(List);
                Console.WriteLine("Your BikeID is:{0}", bike.ID);
                return true;

            }
            else
            {
                return false;
            }

        }
        public void RemoveVehicle(string ID,int exitTime)
        {
            for (int i = 0; i < vehicles.Count; i++)
            {
                if (vehicles[i].ID.ToString() == ID)
                {
                    if (vehicles[i].Type=="Car")
                    {
                        Car car = new Car();
                        car.EntryHour = vehicles[i].Enter;
                        car.ExitHour = exitTime;
                        Console.WriteLine("Type={0}",vehicles[i].Type.ToString());
                        Console.WriteLine("EntryHour={0}",car.EntryHour);
                        Console.WriteLine("ExitHour={0}",car.ExitHour);
                        Console.WriteLine("Cost={0}", car.GetCost().ToString("###")+"Rls");
                        Console.WriteLine("Remove Success!");
                        Console.Write("Please Tell Us Your Comment= ");
                        string comment = Console.ReadLine();
                        Comment(comment);
                        total.Add(car.GetCost());
                        vehicles.RemoveAt(i);
                        result = 1;
                    }
                    else if (vehicles[i].Type=="Bike")
                    {
                        Bike bike = new Bike();
                        bike.EntryHour = vehicles[i].Enter;
                        bike.ExitHour = exitTime;
                        Console.WriteLine("Type={0}", vehicles[i].Type.ToString());
                        Console.WriteLine("EntryHour={0}", bike.EntryHour);
                        Console.WriteLine("ExitHour={0}", bike.ExitHour);
                        Console.WriteLine("Cost={0}", bike.GetCost().ToString("###") + "Rls");
                        Console.WriteLine("Remove Success!");
                        Console.Write("Please Tell Us Your Comment= ");
                        string comment = Console.ReadLine();
                        Comment(comment);
                        total.Add(bike.GetCost());
                        vehicles.RemoveAt(i);
                        result = 1;
                    }
                    
                }
            }
        }
        public void GetTotal()
        {
            if (total.Count > 0)
            {
                foreach (var item in total)
                {
                    res += item;
                }
                Console.WriteLine("Total Income={0}" , res.ToString("###") + "Rls");
            }
            else
            {
                Console.WriteLine("Total Income={0}", res + "Rls");
            }
        }

        public void Comment(string commnet)
        {
            // Add input data
            var input = new ModelInput()
            {
                Col0 = commnet
            };

            // Load model and predict output of sample data
            ModelOutput result = ConsumeModel.Predict(input);
            // If Prediction is 1, sentiment is "Positive"; otherwise, sentiment is "Negative"
            string sentiment = result.Prediction == "1" ? "Positive" : "Negative";
            Console.WriteLine($"Thank you For Your {sentiment} Comment");
        }
    }
    public struct list
    {
        public Guid ID;
        public  string Type;
        public  int Enter;
    }
}
