using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Service
{
    public class DataItem
    {
        public string Title { get; set; }
        public Enum Type { get; set; }

        public static void Test()
        {
            Debug.WriteLine("Works");
        }
    }
}
