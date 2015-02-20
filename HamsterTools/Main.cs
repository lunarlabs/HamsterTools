﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace HamsterTools
{
    class Kickstart
    {
        static void Main(string[] args)
        {
            Debug.WriteLine("HamsterTools, " + OHRRPGCE.CompatibleVersion + "-compatible");
            Debug.WriteLine("Written by Matthias Lamers 2014-2015");
            Debug.WriteLine("OHRRPGCE lump file version " + OHRRPGCE.CurrentRPGVersion);
            Debug.WriteLine("RSAV version " + OHRRPGCE.CurrentRSAVVersion);
            Debug.WriteLine("");

            string thefile = @"C:\OHRRPGCE\vikings.rpg";
            LumpManager.unLump(thefile);

            thefile = @"C:\OHRRPGCE\vikings.rpg.hwtmp\GENERAL.RELD";
            Reload.ReloadFileIO.readReloadFile(thefile);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HomeScreen());
        }
    }
}