﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterTools
{
    public static class OHRRPGCE
    {
        //This is the big constants file. See const.bi in OHRRPGCE source.
        /*
         *OHRRPGCE CUSTOM constants 
         */
        public const string CompatibleVersion = "callipygous";
        public const int CurrentRPGVersion = 19;
        // It is a good idea to increment this number each time a major feature
        // has been added, if opening a new game in an old editor would cause data-loss
        // Don't be afraid to increment this. Backcompat warnings are a good thing!
        //--version history
        // 7 - ypsiliform wip added > 36 NPC defs (and many other features)
        // 8 - ypsiliform wip added extended chaining data (and many other features)
        // 9 - ypsiliform wip added text box sound effects
        // 10 - ypsiliform wip added attack-based enemy transmogrification
        // 11 - zenzizenzic wip added variable record size and record number .N## lumps
        // 12 - zenzizenzic wip increased .N## record size
        // 13 - zenzizenzic wip changed password format to PW4, older versions have broken genPassVersion handling
        // 14 - zenzizenzic wip made .DT0 binsize-sized
        // 15 - zenzizenzic wip made .DT1 binsize-sized, and added binsize.bin, fixbits.bit safeguards
        // 16 - zenzizenzic wip made .ITM binsize-sized
        // 17 - alectormancy wip increase global limit from 4095 to 16383
        // 18 - beelzebufo turn-based support
        // 19 - beelzebufo replaced .DT0 with heroes.reld
        public const int CurrentRSAVVersion = 3;
        // Increment this number any time that loading and resaving a game in either
        // new or old versions of Game leads to data-loss, or major new features are
        // added.
        // 1 - zenzizenzic wip removed nativehbits related nodes
        // 2 - alectormancy wip increased global limit from 4095 to 16383
        // 3 - stopped writing obsolete battle_menus node

        
        public enum Stats
        {
            HP, MP, Attack, Aim, Defense, Dodge, Magic, Will, Speed, Counter, Focus, ExtraHits, User
        }
        public const int LastStat = 11;

        public enum StatsAt
        {
            Lv0, Lv99
        }

        public enum Fix //quirks bits
        {
            AttackItems, WeaponPoints, StunCancelTarget, DefaultDissolve, DefaultEnemyDissolve, PushNPCBugCompatibility,
            DefaultMaxItem, BlankDoorLinks, ShopSounds, ExtendedNPCs, HeroPortrait, TextBoxPortrait, NPCLocationFormat,
            InitDamageDisplay, DefaultLevelCap, HeroElementals, OldElementalFailBit, AttackElementFails, EnemyElementals,
            ItemElementals, NumElements, RemoveDamageMP, DefaultMaxLevel, Unused23
        }
        public const int FixBitsSize = 23;

        public enum GameErrorHandling
        {
            Default, Reserved, ShowAllWarnings, SuppressSomeWarnings, SuppressWeakTypeChecking, DoNotShowNewErrors,
            CorruptionOrIntepreterOnly
        }

        public enum ScriptErrorType
        {
            Information, Warning, SuspiciousOperation, Bounds, BadOperation, Error, EngineBug
        }

        /// <summary>
        /// The way the game engine handles equipment elemental resistances.
        /// </summary>
        public enum EquipmentElementMath
        {
            /// <summary>
            /// The old buggy way. Not recommended.
            /// </summary>
            Stupid, 

            /// <summary>
            /// Equipment resistances are added to the base resistance.
            /// </summary>
            Additive, 

            /// <summary>
            /// Equipment resistances are multipliers.
            /// </summary>
            Multiplicative
        }

        public enum InventoryAutosortMethod
        {
            ByType, ByUsability, Alphabetically, ByID, JustRemoveBlanks
        }
        /*
         * RELOAD constants
         */

        /// <summary>
        /// The string "RELD". All RELOAD files have this as the first four bytes.
        /// </summary>
        public const int ReloadMagicNumber = 0x444c4552; 
        // "RELD" ... if it doesn't have this as the first 4 bytes it's NOT a reload file!
        
        /// <summary>
        /// The latest RELOAD version that can be handled.
        /// </summary>
        public const byte ReloadVersionNumber = 1;
        // Remember to keep up to date with the email list about RELOAD developments.
        
        /// <summary>
        /// The size of the RELOAD header.
        /// </summary>
        public const int ReloadHeaderSize = 13;
        // Why a int32? Ask TMC or whoever made the RELOAD spec...
    }
}
