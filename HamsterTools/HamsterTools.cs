using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HamsterTools
{
    class Kickstart
    {
        static void Main(string[] args)
        {
            string thefile = @"C:\OHRRPGCE\vikings.rpg";
            Console.WriteLine(Path.GetFullPath(thefile));
            LumpManager.unLump(thefile);
        }
    }
}
