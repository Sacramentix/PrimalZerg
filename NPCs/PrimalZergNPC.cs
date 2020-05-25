using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PrimalZerg.NPCs
{
    public class PrimalZergNPC : GlobalNPC
    {
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            PrimalZergPlayer modPlayer = player.GetModPlayer<PrimalZergPlayer>();
            if (modPlayer.zergMucus == true) {
                maxSpawns = (int)(maxSpawns*modPlayer.zergMucusMaxSpawns);
                spawnRate = (int)(spawnRate/modPlayer.zergMucusSpawnRate);
            }
            if (PrimalZerg.showSpawnInfo) {
                Main.NewText("Actual spawn rate : " + spawnRate, Color.Purple);
                Main.NewText("Actual spawn cap : " + maxSpawns, Color.Purple);
                PrimalZerg.showSpawnInfo = false;
            }
        }
    }
}