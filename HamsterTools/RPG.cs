using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterTools
{
    public sealed class RPG
    {
        private static readonly RPG instance = new RPG();

        private string archnym;


        static RPG()
        {

        }

        private RPG()
        {

        }

        public static RPG Instance
        {
            get
            {
                return instance;
            }
        }

        public void ReadFromFile(string fileName)
        {

        }

        public void WriteToFile(string fileName)
        {

        }
    }
}
