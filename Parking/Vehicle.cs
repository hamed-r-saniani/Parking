using System;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    public abstract class Vehicle
    {
        public enum VehicleType
        {
            Car,Bike
        }
        public Guid ID { get; set; }
        public VehicleType Type { get; set; }
        public Vehicle(Guid ID)
        {
            this.ID = ID;
        }
    }
}
