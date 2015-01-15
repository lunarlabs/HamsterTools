using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterTools.Reload
{
    class Reload
    {

    }

    class ReloadNode
    {
        //Declarations
        private ReloadNodeType type;
        private string nodeName;
        private byte byteData;
        private short int16Data;
        private int int32Data;
    }

    enum ReloadNodeType
    {
        Null, Byte, Int16, Int32, Int64, Double, String
    }
}
