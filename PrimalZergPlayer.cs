using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace PrimalZerg
{

	public class PrimalZergPlayer : ModPlayer
	{
        public bool zergMucus;
        public float zergMucusSpawnRate;
        public float zergMucusMaxSpawns;

        public override void ResetEffects() {
            zergMucus = false;
            zergMucusSpawnRate = 30;
            zergMucusMaxSpawns = 60;
        }
    }
}