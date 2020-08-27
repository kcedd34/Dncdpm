using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;


namespace Dncdpm
{
    class Program
    {
        
        static void Main()
        {
            Start();
        }

        public static void Start()
        {
            Timer timer = new Timer(1000);
            timer.Elapsed += Balance.Run;
            timer.Start();
            while (true)
            {
                // Infinite loop.
            }
        }
    }
}
