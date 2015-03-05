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

        private List<ReloadNode> _children = new List<ReloadNode>();
        
        /// <summary>
        /// A List containing the node's children.
        /// </summary>
        /// <remarks>Instead of using Children.Add and Children.Insert, use addChild and insertChild
        /// to properly set the parent.</remarks>
        public List<ReloadNode> Children
        {
            get
            {
                return _children;
            }
        }

        public int NumberOfChildren
        {
            get
            {
                return _children.Count;
            }
        }

        private ReloadNode parent = null;
        public ReloadNode Parent
        {
            get
            {
                return parent;
            }
        }

        public string toString()
        {
            return _nodeName;
        }

        //constructors

        /// <summary>
        /// Creates a Null ReloadNode.
        /// </summary>
        public ReloadNode()
        {
            //No argument means a null node type.
            _type = ReloadNodeType.Null;
        }

        /// <summary>
        /// Creates a Byte ReloadNode.
        /// </summary>
        /// <param name="bData">The node's data.</param>
        public ReloadNode(byte bData){
            _type=ReloadNodeType.Byte;
            _byteData = bData;
        }

        /// <summary>
        /// Creates a 16-Bit Integer ReloadNode.
        /// </summary>
        /// <param name="sData">The node's data.</param>
        public ReloadNode(short sData)
        {
            _type = ReloadNodeType.Int16;
            _int16Data = sData;
        }

        /// <summary>
        /// Creates a 32-Bit Integer ReloadNode.
        /// </summary>
        /// <param name="iData">The node's data.</param>
        public ReloadNode(int iData)
        {
            _type = ReloadNodeType.Int32;
            _int32Data = iData;
        }

        /// <summary>
        /// Creates a 64-Bit Integer ReloadNode.
        /// </summary>
        /// <param name="lData">The node's data.</param>
        public ReloadNode(long lData)
        {
            _type = ReloadNodeType.Int64;
            _int64Data = lData;
        }

        /// <summary>
        /// Creates a Double-Precision Float ReloadNode.
        /// </summary>
        /// <param name="dData">The node's data.</param>
        public ReloadNode(double dData)
        {
            _type = ReloadNodeType.Double;
            _doubleData = dData;
        }

        /// <summary>
        /// Creates a String ReloadNode.
        /// </summary>
        /// <param name="sData">The node's data.</param>
        public ReloadNode(string sData)
        {
            _type = ReloadNodeType.String;
            _stringData = sData;
        }

        /// <summary>
        /// Checks to see if a ReloadNode has an immediate child with a certain name.
        /// </summary>
        /// <param name="name">The name of the child to look for.</param>
        /// <returns>Returns true if there is an immediate child with the name, or false otherwise.</returns>
        public bool hasChild(String name)
        {
            return (getPositionOfChild(name) > 1);
        }

        /// <summary>
        /// Returns the position of node's immediate named child.
        /// </summary>
        /// <param name="name">The name of the child to look for</param>
        /// <returns>The position of the child in children, or -1 if the child was not found.</returns>
        public int getPositionOfChild(String name)
        {
            for (int i = 0; i < _children.Count; i++)
            {
                if (_children[i].Name == name)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Returns a node's immediate named child.
        /// </summary>
        /// <param name="name">The name of the child to get.</param>
        /// <returns>The named child, or <c>null</c> if there is no child with that name.</returns>
        public ReloadNode getChild(String name)
        {
            for (int i = 0; i < _children.Count; i++)
            {
                if (_children[i].Name == name)
                {
                    return _children[i];
                }
            }
            return null;
        }

        /// <summary>
        /// Returns an immediate child node.
        /// </summary>
        /// <param name="index">The number of the child to get</param>
        /// <returns>The child node.</returns>
        public ReloadNode getChild(int index)
        {
            return _children[index];
        }

        public void addChild(ReloadNode node)
        {
            node.parent = this;
            _children.Add(node);
        }

        public void insertChild(ReloadNode node, int index)
        {
            node.parent = this;
            _children.Insert(index, node);
        }

    }

    public class ReloadFileIO
    {
        /// <summary>
        /// Reads a RELOAD file and turns it into a ReloadNode.
        /// </summary>
        /// <param name="reloadFileLocation">The file path of the RELOAD file.</param>
        /// <returns>A ReloadNode containing the node structure of the RELOAD file.</returns>
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
                        int magicNumberCheck = b.ReadInt32();
                        if (magicNumberCheck != OHRRPGCE.ReloadMagicNumber)
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

        /// <summary>
        /// Writes a ReloadNode and its associated tree to a file.
        /// </summary>
        /// <param name="reloadFileLocation">The file to write the ReloadNode to.</param>
        /// <param name="inNode">The ReloadNode to write.</param>
        /// <remarks>This will overwrite the target file. Make sure you know what you're doing!</remarks>
        public static void writeReloadFile(string reloadFileLocation, ReloadNode inNode)
        {
            List<string> names = new List<string>();
            int stringMember = 1;
            int stringTableLocation;

            using (FileStream outFile = new FileStream(reloadFileLocation, FileMode.Create))
            {
                using (BinaryWriter b = new BinaryWriter(outFile))
                {
                    //Write the preamble first
                    b.Write(OHRRPGCE.ReloadMagicNumber);
                    b.Write(OHRRPGCE.ReloadVersionNumber);
                    b.Write(OHRRPGCE.ReloadHeaderSize);
                    b.Write((int)0); //We'll get back to the string table soon.

                    //now the node content
                    writeOut(b, inNode, names);

                    //After that, define where the string table is
                    stringTableLocation = (int)b.BaseStream.Position;
                    b.BaseStream.Seek(9, SeekOrigin.Begin);
                    b.Write(stringTableLocation);

                    //and then go back to where we'll write the string data
                    b.BaseStream.Seek(stringTableLocation, SeekOrigin.Begin);

                    foreach (string nodeName in names)
                    {
                        writeVLI(b, stringMember);
                        writeString(b, nodeName);
                        stringMember++;
                    }
                    
                }
            }
        }

        private static void writeOut(BinaryWriter bw, ReloadNode node, List<string> nameList)
        {
            long startLocation = bw.BaseStream.Position;
            long flashbackLocation;
            int nodeLength;

            bw.Write((int)0); //We'll get back to the length later.

            nameList.Add(node.Name);
            int tablePosition = nameList.Count;
            writeVLI(bw, tablePosition);

            switch (node.Type)
            {
                case ReloadNodeType.Null:
                    bw.Write((byte)0);
                    break;
                case ReloadNodeType.Byte:
                    bw.Write((byte)1);
                    bw.Write(node.ByteData);
                    break;
                case ReloadNodeType.Int16:
                    bw.Write((byte)2);
                    bw.Write(node.Int16Data);
                    break;
                case ReloadNodeType.Int32:
                    bw.Write((byte)3);
                    bw.Write(node.Int32Data);
                    break;
                case ReloadNodeType.Int64:
                    bw.Write((byte)4);
                    bw.Write(node.Int64Data);
                    break;
                case ReloadNodeType.Double:
                    bw.Write((byte)5);
                    bw.Write(node.DoubleData);
                    break;
                case ReloadNodeType.String:
                    bw.Write((byte)6);
                    writeString(bw, node.StringData);
                    break;
                default:
                    Debug.WriteLine("Something went wrong!");
                    break;
            }

            writeVLI(bw, node.Children.Count);

            foreach (ReloadNode child in node.Children)
            {
                writeOut(bw, child, nameList);
            }

            flashbackLocation = bw.BaseStream.Position;
            nodeLength = (int)(flashbackLocation - startLocation) - 4;
            bw.BaseStream.Seek(startLocation, SeekOrigin.Begin);
            bw.Write(nodeLength);
            bw.BaseStream.Seek(flashbackLocation, SeekOrigin.Begin);
        }

        private static void writeString(BinaryWriter bw, string s)
        {
            writeVLI(bw, s.Length);
            char[] charArray = s.ToCharArray();
            foreach (char c in charArray)
            {
                bw.Write((byte)c);
            }
        }

        // VLI methods
        /*
         * A VLI is a variable-length integer.
         * 
         * The first byte is of the format:
         * CNxxxxxx
         * where C is a flag that indicates whether there are more bytes in the VLI and N is a negation flag.
         * 
         * Subsequent bytes are of the format
         * Cxxxxxxx.
         * 
         */


        /// <summary>
        /// Reads a variable-length integer from a file.
        /// </summary>
        /// <param name="br"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Writes a integer to a file as a variable-length integer.
        /// </summary>
        /// <param name="bw">The BinaryWriter pointing to the file to write to.</param>
        /// <param name="num">The integer to write as a VLI.</param>
        private static void writeVLI(BinaryWriter bw, int num)
        {
            bool isNegative = (num < 0);
            bool isSingleByte = true;
            int a = num;
            int b;
            if (isNegative) a = Math.Abs(a);

            b = a & 0x3f;
            if (isNegative) b += 0x40;
            if (a >= 0x40)
            {
                b += 0x80;
                isSingleByte = false;
            }

            bw.Write(b);

            a = a >> 6;

            //if the number is a single byte, this is skipped
            while (a > 0x80)
            {
                b = (a & 0x7f);
                b += 0x80;
                bw.Write(b);
                a = a >> 7;
            }
            //we write the last byte of a multi-byte VLI here.
            if (!isSingleByte)
            {
                b = (a & 0x7f);
                bw.Write(b);
            }

        }

    }

    public enum ReloadNodeType
    {
        Null, Byte, Int16, Int32, Int64, Double, String
    }
}
