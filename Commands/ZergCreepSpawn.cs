using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace PrimalZerg.Commands
{
	public class SetSpawnRate : ModCommand
	{
		public override CommandType Type
			=> CommandType.Chat;

		public override string Command
			=> "PrimalZergSpawnRate";

		public override string Usage
			=> "/PrimalZergSpawnRate spawnRate";

		public override string Description
			=> "Change the spawn rate boost of the zerg creep concoction.";

		public override void Action(CommandCaller caller, string input, string[] args) {
            double value;
            bool isParsed = double.TryParse(args[0], out value);
            if (isParsed) {
                PrimalZergPlayer modPlayer = caller.Player.GetModPlayer<PrimalZergPlayer>();
                modPlayer.zergMucusSpawnRate = value;
				caller.Reply("The spawn rate boost of the concoction is now : " + modPlayer.zergMucusSpawnRate.ToString(), Color.Purple);
				if(Main.netMode != NetmodeID.SinglePlayer) {
					ModPacket packet = mod.GetPacket();
					packet.Write((byte)PrimalZergMessageType.ChangeZergMucusSpawnRate);
					packet.Write((byte)caller.Player.whoAmI);
					packet.Write(value);
					packet.Send();
				}

            } else {
                throw new UsageException("spawn rate value must be an number!");
            }
		}
	}

    public class SetSpawnRateShorcut : SetSpawnRate
	{
		public override string Command
			=> "PZSpawnRate";

		public override string Usage
			=> "/PZSpawnRate spawnRate";

	}

    public class SetSpawnCap : ModCommand
	{
		public override CommandType Type
			=> CommandType.Chat;

		public override string Command
			=> "PrimalZergSpawnCap";

		public override string Usage
			=> "/PrimalZergSpawnCap spawnCap";

		public override string Description
			=> "Change the spawn cap boost of the zerg creep concoction.";

		public override void Action(CommandCaller caller, string input, string[] args) {
            double value;
            bool isParsed = double.TryParse(args[0], out value);
            if (isParsed) {
                PrimalZergPlayer modPlayer = caller.Player.GetModPlayer<PrimalZergPlayer>();
                modPlayer.zergMucusMaxSpawns = value;
				caller.Reply("The spawn cap boost of the concoction is now : " + modPlayer.zergMucusMaxSpawns.ToString(), Color.Purple);
				if(Main.netMode != NetmodeID.SinglePlayer) {
					ModPacket packet = mod.GetPacket();
					packet.Write((byte)PrimalZergMessageType.ChangeZergMucusMaxSpawns);
					packet.Write((byte)caller.Player.whoAmI);
					packet.Write(value);
					packet.Send();
				}
            } else {
                throw new UsageException("spawn cap value must be an number!");
            }
		}
	}

    public class SetSpawnCapShorcut : SetSpawnCap
	{

		public override string Command
			=> "PZSpawnCap";

		public override string Usage
			=> "/PZSpawnCap spawnCap";

	}

	public class Info : ModCommand
	{
		public override CommandType Type
			=> CommandType.Chat;

		public override string Command
			=> "PrimalZergInfo";

		public override string Usage
			=> "/PrimalZergInfo";

		public override string Description
			=> "Show informartion about primal zerg such as spawn rate and cap boost of the zerg creep concoction";

		public override void Action(CommandCaller caller, string input, string[] args) {
            PrimalZergPlayer modPlayer = caller.Player.GetModPlayer<PrimalZergPlayer>();
			caller.Reply("spawn rate boost of the concoction : " + modPlayer.zergMucusSpawnRate.ToString(), Color.Purple);
			caller.Reply("spawn cap boost of the concoction : " + modPlayer.zergMucusMaxSpawns.ToString(), Color.Purple);
			PrimalZerg.showSpawnInfo = true;
		}
	}

	public class InfoShorcut : Info
	{
		public override string Command
			=> "PZInfo";

		public override string Usage
			=> "/PZInfo";

	}


}