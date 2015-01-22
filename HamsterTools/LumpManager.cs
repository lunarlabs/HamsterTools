using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterTools
{
    public static class LumpManager
    {
        // private const long[] PDPOffsets = { 256 ^ 2, 256 ^ 3, 256 ^ 0, 256 ^ 1 };
        // Only used here for some reason. Used to get the length of lumps.

        // PDP endianness: high, highest, lowest, low

        
        public static void unLump(string sourceFileLocation, string destinationDirectory)
        {
            bool _endOfFile = false;
            string _fileName;
            byte b;
            byte[] _PDPlength;
            int _length;

            if (System.IO.File.Exists(sourceFileLocation))
            {
                Console.WriteLine("Unlumping " + Path.GetFileName(sourceFileLocation) + " to "
                    + destinationDirectory + "...");
                if (Directory.Exists(destinationDirectory))
                {
                    Console.WriteLine("Directory exists, files may be overwritten.");
                }
                else
                {
                    Directory.CreateDirectory(destinationDirectory);
                }

                using (FileStream inFile = new FileStream(sourceFileLocation, FileMode.Open))
                {
                    if (inFile.Length == 0)
                    {
                        throw new EndOfStreamException("File is zero bytes");
                    }
                    using (BinaryReader r = new BinaryReader(inFile))
                    {
                        while (_endOfFile == false)
                        {

                            StringBuilder extractedFileName = new StringBuilder(50);
                            //read the file name until we hit NUL

                            b = r.ReadByte();
                            do
                            {
                                if (inFile.Position == inFile.Length)
                                {
                                    throw new EndOfStreamException("Reached the end of the file while reading file name");
                                }
                                extractedFileName.Append((char)b);
                                b = r.ReadByte();
                            } while (b > 0);
                            _fileName = Path.GetFullPath(destinationDirectory) + Path.DirectorySeparatorChar + extractedFileName.ToString();

                            Console.Write("Unlumping file " + _fileName);

                            //read the length and translate it from PDP-endian to proper format
                            _PDPlength = r.ReadBytes(4);
                            if (_PDPlength.Length != 4)
                            {
                                throw new EndOfStreamException("Reached the end of the file while reading file length");
                            }
                            _length = convertLength(_PDPlength);
                            Console.Write(", " + _length + " bytes... ");

                            //read the file for the length specified
                            using (FileStream outFile = new FileStream(_fileName, FileMode.Create))
                            {
                                using (BinaryWriter w = new BinaryWriter(outFile))
                                {
                                    for (int i = 0; i < _length; i++)
                                    {
                                            w.Write(r.ReadByte());  
                                    }
                                    Console.WriteLine("done.");
                                }
                            }
                            if (inFile.Position == inFile.Length)
                            {
                                _endOfFile = true;
                            }

                        }
                    }   
                    }
                    Console.WriteLine("Finished unlumping!");

            }
            else
            {
                throw new FileNotFoundException("Can't find the lump file: " + sourceFileLocation);
            }
        }

        private static int convertLength(byte[] PDPvalue)
        {
            int result;
            byte[] convertedLength = {PDPvalue[2], PDPvalue[3], PDPvalue[0], PDPvalue[1] };
            result = BitConverter.ToInt32(convertedLength, 0);
            return result;
        }

        public static void unLump(string sourceFileLocation)
        {
            Console.WriteLine("No destination directory specified, unlumping to " + Path.GetFileName(sourceFileLocation) 
                + ".hwtmp...");
            string tempDir = sourceFileLocation + ".hwtmp";
            unLump(sourceFileLocation, tempDir);
        }

        public static void lump(string sourceDirectory, string lumpDestination, bool deleteAfterwards)
        {

        }
    }
}
