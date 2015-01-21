using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HamsterTools
{
    public static class LumpManager
    {
        // private const long[] PDPOffsets = { 256 ^ 2, 256 ^ 3, 256 ^ 0, 256 ^ 1 };
        // Only used here for some reason. Used to get the length of lumps.

        // PDP endianness: high, highest, lowest, low

        private System.IO.File lump;
        private System.IO.Directory unlumpedDirectory;
        private byte[] _PDPlength;

        
        public static void unLump(string sourceFileLocation, string destinationFileName)
        {
            bool _endOfFile = false;
            string _fileName;
            long _length;

            if (File.Exists(sourceFileLocation))
            {
                Console.WriteLine("Unlumping " + Path.GetFileName(sourceFileLocation) + " to "
                    + Path.GetDirectoryName(destinationFileName) + "...");
                if (Directory.Exists(destinationFileName))
                {
                    Console.WriteLine("Directory exists, files may be overwritten.");
                }
                else
                {
                    Directory.CreateDirectory(sourceFileLocation);
                }

                using (FileStream inFile = new FileStream(sourceFileLocation, FileMode.Create))
                {
                    using (BinaryReader r = new BinaryReader(inFile))
                    {
                        byte readByte;
                        StringBuilder extractedFileName = new StringBuilder();
                        //read the file name until we hit NUL
                        if (inFile.Length == 0)
                        {
                            throw new EndOfStreamException("File is zero bytes");
                        }
                        readByte = r.ReadByte();
                        do
                        {
                            if (inFile.Position == inFile.Length)
                            {
                                throw new EndOfStreamException("Reached the end of the file while reading file name");
                            }
                            extractedFileName.Append((char)readByte);
                        } while (readByte > 0);

                        //read the length and translate it from PDP-endian to proper format

                        //read the file for the length specified
                    }
                }

            }
            else
            {
                throw new FileNotFoundException("Can't find the lump file: " + sourceFileLocation);
            }
        }

        public static void unLump(string sourceFileLocation)
        {
            Console.WriteLine("No destination directory specified, unlumping to " + Path.GetFileName(sourceFileLocation) 
                + ".hwtmp...");
            string tempDir = Path.GetFullPath(sourceFileLocation) + ".hwtwmp";
            unLump(sourceFileLocation, tempDir);
        }

        public static void lump(string sourceDirectory, string lumpDestination)
        {

        }
    }
}
