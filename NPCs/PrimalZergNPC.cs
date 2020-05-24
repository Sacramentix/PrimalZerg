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
        }
    }
}