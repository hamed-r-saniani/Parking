using System;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
     public class Car : Vehicle, IParkable
    {
        public Car() : base(Guid.NewGuid()) 
        {

        }
        public int EntryHour { get; set; }
        public int ExitHour { get ; set; }
        public int EntrancePrice { get; set; } = 50000;
        public int HourPrice { get; set; } = 20000;
        

        public int GetCost()
        {
            return EntrancePrice + ((ExitHour-EntryHour) * HourPrice);
        }
    }
}
