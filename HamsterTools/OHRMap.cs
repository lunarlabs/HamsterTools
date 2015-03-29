using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterTools
{
    class OHRMap
    {
        //T
        private short _width;
        private short _height;

        //MN
        private string _mapName;

        //MAP
        private short _defaultTileset;
        private short _ambientMusic;
        private short _miniMapAvailable;
        private short _saveAnywhere;
        private short _mapNameDisplayTime;
        private MapEdge _mapEdgeMode;
        private short _defaultEdgeTile;
        private short _autoRunScriptTrigger;
        private short _autoRunScriptTriggerArg;
        private short _harmTileDamage;
        private short _harmTileFlashColor;
        private short _footOffset;
        private short _afterBattleScriptTrigger;
        private short _insteadOfBattleScriptTrigger;

        public enum MapEdge
        {
            Crop, Wrap, UseDefaultEdgeTile
        }
    }

    class OHRMapLayer
    {
        private short _tileset;
        private byte[,] _tiles;
        private string _name;
    }
}
