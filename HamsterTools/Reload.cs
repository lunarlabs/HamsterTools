using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterTools.Reload
{

    public class ReloadNode
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
        public int NumberOfChildren
        {
            get
            {
                return children.Count;
            }
        }

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
        public bool hasChild(String name)
        {
            return (getPositionOfChild(name) > 1);
        }

        public int getPositionOfChild(String name)
        {
            for (int i = 0; i < children.Count; i++)
            {
                if (children[i].Name == name)
                {
                    return i;
                }
            }
            return -1;
        }

        public ReloadNode getChild(String name)
        {
            for (int i = 0; i < children.Count; i++)
            {
                if (children[i].Name == name)
                {
                    return children[i];
                }
            }
            return null;
        }

        public ReloadNode getChild(int index)
        {
            return children[index];
        }

        public void addChild(ReloadNode node)
        {
            children.Add(node);
        }

        public void insertChild(ReloadNode node, int index)
        {
            children.Insert(index, node);
        }

    }

    public class ReloadFileIO
    {
        //TODO Write this class.
        public static ReloadNode readReloadFile(string reloadFileLocation)
        {
            ReloadNode result = null;
            int stringTablePosition;

            if (File.Exists(reloadFileLocation))
            {
                Debug.WriteLine("Checking header of " + reloadFileLocation + "...");
                using (FileStream inFile = new FileStream(reloadFileLocation, FileMode.Open))
                {
                    if (inFile.Length < OHRRPGCE.ReloadHeaderSize)
                    {
                        throw new EndOfStreamException("File is too small to be a RELOAD file");
                    }
                    using (BinaryReader b = new BinaryReader(inFile))
                    {
                        byte[] magicNumberCheck = b.ReadBytes(4);
                        if (magicNumberCheck.SequenceEqual(OHRRPGCE.ReloadMagicNumber) == false)
                        {
                            throw new FileFormatException(reloadFileLocation + " is not a RELOAD file!");
                        }
                        
                        byte versionCheck = b.ReadByte();
                        if (versionCheck != OHRRPGCE.ReloadVersionNumber)
                        {
                            throw new FileFormatException(reloadFileLocation + " has RELOAD version " + versionCheck 
                                + ", needed " + OHRRPGCE.ReloadVersionNumber);
                        }

                        int headerLengthCheck = b.ReadInt32();
                        if (headerLengthCheck != OHRRPGCE.ReloadHeaderSize)
                        {
                            throw new FileFormatException("Found header length " + headerLengthCheck + ", was expecting "
                                + OHRRPGCE.ReloadHeaderSize);
                        }

                        stringTablePosition = b.ReadInt32();
                        Debug.WriteLine("Looks sane. Node name offset at " + stringTablePosition);

                        result = readIn(b, stringTablePosition);
                    }
                }
                Debug.WriteLine("Done reading RELOAD file, no errors.");
                return result;
            }
            else
            {
                throw new FileNotFoundException("Can't find the RELOAD file:" + reloadFileLocation);
            }
        }

        private static ReloadNode readIn(BinaryReader br, int stringTablePosition)
        {
            ReloadNode result = null;
            Debug.Indent();

            int nodeLength = br.ReadInt32();
            Debug.Write("I see a new node, length " + nodeLength);
            
            int nameID = readVLI(br);
            Debug.Write(", ID is " + nameID);

            int type = br.ReadByte();
            Debug.WriteLine(", type is " + type + "...");

            //create the node based on data type
            switch (type)
            {
                case 0:
                    result = new ReloadNode();
                    break;
                case 1:
                    result = new ReloadNode(br.ReadByte());
                    break;
                case 2:
                    result = new ReloadNode(br.ReadInt16());
                    break;
                case 3:
                    result = new ReloadNode(br.ReadInt32());
                    break;
                case 4:
                    result = new ReloadNode(br.ReadInt64());
                    break;
                case 5:
                    result = new ReloadNode(br.ReadDouble());
                    break;
                case 6:
                    int strLen = readVLI(br);
                    if (strLen > nodeLength)
                    {
                        throw new InvalidDataException("String length is bad or pointer is misplaced.");
                    }
                    StringBuilder sb = new StringBuilder(strLen);
                    for (int i = 0; i < strLen; i++)
                    {
                        sb.Append((char)br.ReadByte());
                    }
                    Debug.WriteLine(sb.ToString());
                    result = new ReloadNode(sb.ToString());
                    break;
                default:
                    Debug.Write(" I don't know how to handle it");
                    throw new InvalidDataException("Don't know how to handle type " + type);
            }

            //jump to name table
            long position = br.BaseStream.Position;
            br.BaseStream.Seek(stringTablePosition, SeekOrigin.Begin);

            //sanity check
            if (nameID > readVLI(br))
            {
                throw new InvalidDataException("Called non-existent string ID or string table counter is incorrect");
            }

            for (int i = 1; i < nameID; i++)
            {
                //skip other strings until we get to our name
                br.BaseStream.Seek((long)readVLI(br), SeekOrigin.Current);
            }
            int nameLen = readVLI(br);
            StringBuilder nodeName = new StringBuilder(nameLen);
            for (int i = 0; i < nameLen; i++)
            {
                nodeName.Append((char)br.ReadByte());
            }
            Debug.WriteLine("name is " + nodeName.ToString() + "...");
            result.Name = nodeName.ToString();

            //hop back to where we were
            br.BaseStream.Seek(position, SeekOrigin.Begin);
            int children = readVLI(br);
            if (children == 0)
            {
                Debug.WriteLine("it has no children.");
            }
            else
            {
                Debug.WriteLine(children + " subnodes.");
                for (int i = 0; i < children; i++)
                {
                    Debug.WriteLine("Child " + (i + 1) + " of " + children + ":");
                    ReloadNode child = readIn(br, stringTablePosition);
                    result.addChild(child);
                }
                Debug.WriteLine("Finished getting children of " + result.Name);
            }

            Debug.Unindent();
            return result;
        }

        private static int readVLI(BinaryReader br)
        {
            bool isNegative = false;
            int b = 0;
            int c = 0;
            int offset = 6;
            int result = 0;

            b = br.ReadByte();
            if ((b & 0x40) != 0) isNegative = true;
            result = b & 0x3F;

            while ((b & 0x80) != 0)
            {
                b = br.ReadByte();
                c = b & 0x7F;
                c = c << offset;
                result += c;
                offset += 7;
            }

            if (isNegative) result = result * -1;

            return result;
        }

        public static void writeReloadFile(string reloadFileLocation, ReloadNode inNode)
        {

        }
    }

    public enum ReloadNodeType
    {
        Null, Byte, Int16, Int32, Int64, Double, String
    }
}
