using System;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    public interface IParkable
    {
        public int EntryHour { get; set; }
        public int ExitHour { get; set; }
        public int EntrancePrice { get; set; }
        public  int HourPrice { get; set; }
        public int GetCost();
    }
}
