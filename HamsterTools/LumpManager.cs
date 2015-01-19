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
        private byte[] _length;

        
        public static void unLump(string sourceFileLocation, string destinationFileName)
        {
            Console.WriteLine("Unlumping " + Path.GetFileName(sourceFileLocation) + " to " 
                + Path.GetDirectoryName(destinationFileName) +"...");

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
