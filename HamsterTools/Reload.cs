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
        private ReloadNodeType _type;
        public ReloadNodeType Type
        {
            get
            {
                return _type;
            }
        }

        private string _nodeName;
        public string Name
        {
            get
            {
                return _nodeName;
            }
            set
            {
                _nodeName = value;
            }
        }

        private byte _byteData;
        public byte ByteData
        {
            get
            {
                if (_type == ReloadNodeType.Byte)
                {
                    return _byteData;
                }
                else
                {
                    string err = "Wrong node type: Tried to read Byte value from a " + _type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
            set
            {
                if (_type == ReloadNodeType.Byte)
                {
                    _byteData = value;
                }
                else
                {
                    string err = "Wrong node type: tried to pass a Byte value to a " + _type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
        }

        private short _int16Data;
        public short Int16Data
        {
            get
            {
                if (_type == ReloadNodeType.Int16)
                {
                    return _int16Data;
                }
                else
                {
                    string err = "Wrong node type: Tried to read Int16 value from a " + _type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
            set
            {
                if (_type == ReloadNodeType.Int16)
                {
                    _int16Data = value;
                }
                else
                {
                    string err = "Wrong node type: tried to pass a Int16 value to a " + _type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
        }

        private int _int32Data;
        public int Int32Data
        {
            get
            {
                if (_type == ReloadNodeType.Int32)
                {
                    return _int32Data;
                }
                else
                {
                    string err = "Wrong node type: Tried to read Int32 value from a " + _type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
            set
            {
                if (_type == ReloadNodeType.Int32)
                {
                    _int32Data = value;
                }
                else
                {
                    string err = "Wrong node type: tried to pass a Int32 value to a " + _type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
        }

        private long _int64Data;
        public long Int64Data
        {
            get
            {
                if (_type == ReloadNodeType.Int64)
                {
                    return _int64Data;
                }
                else
                {
                    string err = "Wrong node type: Tried to read Int64 value from a " + _type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
            set
            {
                if (_type == ReloadNodeType.Int64)
                {
                    _int64Data = value;
                }
                else
                {
                    string err = "Wrong node type: tried to pass a Int64 value to a " + _type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
        }

        private double _doubleData;
        public double DoubleData
        {
            get
            {
                if (_type == ReloadNodeType.Double)
                {
                    return _doubleData;
                }
                else
                {
                    string err = "Wrong node type: Tried to read Double value from a " + _type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
            set
            {
                if (_type == ReloadNodeType.Double)
                {
                    _doubleData = value;
                }
                else
                {
                    string err = "Wrong node type: tried to pass a Double value to a " + _type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
        }
        
        private string _stringData;
        public String StringData
        {
            get
            {
                if (_type == ReloadNodeType.String)
                {
                    return _stringData;
                }
                else
                {
                    string err = "Wrong node type: Tried to read String value from a " + _type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
            set
            {
                if (_type == ReloadNodeType.String)
                {
                    _stringData = value;
                }
                else
                {
                    string err = "Wrong node type: tried to pass a String value to a " + _type.ToString() + " node.";
                    throw new InvalidOperationException(err);
                }
            }
        }

        private List<ReloadNode> children = new List<ReloadNode>();

        //constructors
        public ReloadNode()
        {
            //No argument means a null node type.
            _type = ReloadNodeType.Null;
        }

        public ReloadNode(byte bData){
            _type=ReloadNodeType.Byte;
            _byteData = bData;
        }

        public ReloadNode(short sData)
        {
            _type = ReloadNodeType.Int16;
            _int16Data = sData;
        }

        public ReloadNode(int iData)
        {
            _type = ReloadNodeType.Int32;
            _int32Data = iData;
        }

        public ReloadNode(long lData)
        {
            _type = ReloadNodeType.Int64;
            _int64Data = lData;
        }

        public ReloadNode(double dData)
        {
            _type = ReloadNodeType.Double;
            _doubleData = dData;
        }

        public ReloadNode(string sData)
        {
            _type = ReloadNodeType.String;
            _stringData = sData;
        }

        //TODO Add methods related to children.

    }

    public class ReloadFileIO
    {
        //TODO Write this class.
    }

    enum ReloadNodeType
    {
        Null, Byte, Int16, Int32, Int64, Double, String
    }
}
