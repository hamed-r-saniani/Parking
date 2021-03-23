using System;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
     public class Bike : Vehicle, IParkable
    {
        public Bike() : base(Guid.NewGuid())
        {

        }
        public int EntryHour { get ; set ; }
        public int ExitHour { get ; set ; }
        public int EntrancePrice { get; set; } = 30000;
        public int HourPrice { get; set; } = 10000;

        public int GetCost()
        {
            return EntrancePrice + ((ExitHour - EntryHour) * HourPrice);
        }
    }
}
