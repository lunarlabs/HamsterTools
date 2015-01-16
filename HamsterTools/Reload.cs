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
        private long int64Data;
        private double doubleData;
        private string stringData;
        private List<ReloadNode> children = new List<ReloadNode>();

        //constructors
        public ReloadNode()
        {
            //No argument means a null node type.
            type = ReloadNodeType.Null;
        }

        public ReloadNode(byte bData){
            type=ReloadNodeType.Byte;
            byteData = bData;
        }

        public ReloadNode(short sData)
        {
            type = ReloadNodeType.Int16;
            int16Data = sData;
        }

        public ReloadNode(int iData)
        {
            type = ReloadNodeType.Int32;
            int32Data = iData;
        }

        public ReloadNode(long lData)
        {
            type = ReloadNodeType.Int64;
            int64Data = lData;
        }

        public ReloadNode(double dData)
        {
            type = ReloadNodeType.Double;
            doubleData = dData;
        }

        public ReloadNode(string sData)
        {
            type = ReloadNodeType.String;
            stringData = sData;
        }

    }

    enum ReloadNodeType
    {
        Null, Byte, Int16, Int32, Int64, Double, String
    }
}
