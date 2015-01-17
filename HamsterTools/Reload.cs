using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterTools.Reload
{

    class ReloadNode
    {
        //Declarations
        private ReloadNodeType type;
        public ReloadNodeType Type
        {
            get
            {
                return type;
            }
        }

        private string nodeName;
        public string Name
        {
            get
            {
                return nodeName;
            }
            set
            {
                nodeName = value;
            }
        }

        private byte byteData;
        public byte ByteData
        {
            get
            {
                if (type == ReloadNodeType.Byte)
                {
                    return byteData;
                }
                else
                {
                    string err = "Wrong node type: Tried to read Byte value from a " + type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
            set
            {
                if (type == ReloadNodeType.Byte)
                {
                    byteData = value;
                }
                else
                {
                    string err = "Wrong node type: tried to pass a Byte value to a " + type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
        }

        private short int16Data;
        public short Int16Data
        {
            get
            {
                if (type == ReloadNodeType.Int16)
                {
                    return int16Data;
                }
                else
                {
                    string err = "Wrong node type: Tried to read Int16 value from a " + type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
            set
            {
                if (type == ReloadNodeType.Int16)
                {
                    int16Data = value;
                }
                else
                {
                    string err = "Wrong node type: tried to pass a Int16 value to a " + type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
        }

        private int int32Data;
        public int Int32Data
        {
            get
            {
                if (type == ReloadNodeType.Int32)
                {
                    return int32Data;
                }
                else
                {
                    string err = "Wrong node type: Tried to read Int32 value from a " + type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
            set
            {
                if (type == ReloadNodeType.Int32)
                {
                    int32Data = value;
                }
                else
                {
                    string err = "Wrong node type: tried to pass a Int32 value to a " + type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
        }

        private long int64Data;
        public long Int64Data
        {
            get
            {
                if (type == ReloadNodeType.Int64)
                {
                    return int64Data;
                }
                else
                {
                    string err = "Wrong node type: Tried to read Int64 value from a " + type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
            set
            {
                if (type == ReloadNodeType.Int64)
                {
                    int64Data = value;
                }
                else
                {
                    string err = "Wrong node type: tried to pass a Int64 value to a " + type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
        }

        private double doubleData;
        public double DoubleData
        {
            get
            {
                if (type == ReloadNodeType.Double)
                {
                    return doubleData;
                }
                else
                {
                    string err = "Wrong node type: Tried to read Double value from a " + type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
            set
            {
                if (type == ReloadNodeType.Double)
                {
                    doubleData = value;
                }
                else
                {
                    string err = "Wrong node type: tried to pass a Double value to a " + type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
        }
        
        private string stringData;
        public String StringData
        {
            get
            {
                if (type == ReloadNodeType.String)
                {
                    return stringData;
                }
                else
                {
                    string err = "Wrong node type: Tried to read String value from a " + type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
            set
            {
                if (type == ReloadNodeType.String)
                {
                    stringData = value;
                }
                else
                {
                    string err = "Wrong node type: tried to pass a String value to a " + type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
        }

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

        //TODO Add methods related to children.

    }

    enum ReloadNodeType
    {
        Null, Byte, Int16, Int32, Int64, Double, String
    }
}
