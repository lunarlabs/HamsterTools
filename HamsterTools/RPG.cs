using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterTools.Properties
{
    public sealed class RPG
    {
        //Singleton methods
        private static RPG _instance = null;
        public static RPG Instance
        {
            get
            {
                return _instance;
            }
        }
        private LoadedState _state = LoadedState.NotLoaded;
        public LoadedState State
        {
            get
            {
                return _state;
            }
        }

        private RPG()
        {

        }

        #region Lump Data

        private string _fileLocation;
        private string _folder;

        /// <summary>
        /// The archive file name used in this RPG.
        /// Used for flexible name files, usually "OHRRPGCE" in newer RPG files.
        /// </summary>
        string archinym;

        #endregion

        #region .GEN Data



        #endregion

        private ushort CalculatePWHash(string password)
        {
            if (password.Length == 0) return 0;
            else
            {
                uint hash = 0;
                foreach (char c in password)
                {
                    hash = (uint)(hash * 3 + c * 31);
                }
                return (ushort)((hash & 511) | 512);
            }
        }

        public enum LoadedState
        {
            /// <summary>
            /// No RPG file is loaded.
            /// </summary>
            NotLoaded, 

            /// <summary>
            /// A password exists and no operations can be done on the RPG file until it is provided.
            /// </summary>
            PasswordNeeded, 

            /// <summary>
            /// The password provided did not match what was stored in the GEN file and no operations can be done on the RPG file.
            /// </summary>
            BadPassword,

            /// <summary>
            /// The RPG file is loaded and ready to use.
            /// </summary>
            OK
        }
    }
}
