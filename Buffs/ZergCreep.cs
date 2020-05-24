using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PrimalZerg.Buffs
{
	public class ZergCreep : ModBuff
	{
		public override void SetDefaults()
		{
			DisplayName.SetDefault("Zerg mucus");
			Description.SetDefault("increase the spawn rate and spawn cap");
			Main.debuff[Type] = true;
			canBeCleared = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			PrimalZergPlayer modPlayer = player.GetModPlayer<PrimalZergPlayer>();
			modPlayer.zergMucus = true;
		}
	}
}
