using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PrimalZerg.Commands
{
	public class SetSpawnRate : ModCommand
	{
		public override CommandType Type
			=> CommandType.World;

		public override string Command
			=> "PrimalZergCreepSpawnRate";

		public override string Usage
			=> "/PrimalZergCreepSpawnRate spawnRate";

		public override string Description
			=> "Change the spawn rate boost of the zerg creep concoction.";

		public override void Action(CommandCaller caller, string input, string[] args) {
            float value;
            bool isParsed = float.TryParse(args[0], out value);
            if (isParsed) {
                PrimalZergPlayer modPlayer = caller.Player.GetModPlayer<PrimalZergPlayer>();
                modPlayer.zergMucusSpawnRate = value;
            } else {
                throw new UsageException("spawn rate value must be an float!");
            }
		}
	}

    public class SetSpawnRateShorcut : ModCommand
	{
		public override CommandType Type
			=> CommandType.World;

		public override string Command
			=> "PZCSpawnRate";

		public override string Usage
			=> "/PZCSpawnRate spawnRate";

		public override string Description
			=> "Change the spawn rate boost of the zerg creep concoction.";

		public override void Action(CommandCaller caller, string input, string[] args) {
            new SetSpawnRate().Action(caller, input, args);
		}
	}

    public class SetSpawnCap : ModCommand
	{
		public override CommandType Type
			=> CommandType.World;

		public override string Command
			=> "PrimalZergCreepSpawnCap";

		public override string Usage
			=> "/PrimalZergCreepSpawnCap spawnCap";

		public override string Description
			=> "Change the spawn cap boost of the zerg creep concoction.";

		public override void Action(CommandCaller caller, string input, string[] args) {
            float value;
            bool isParsed = float.TryParse(args[0], out value);
            if (isParsed) {
                PrimalZergPlayer modPlayer = caller.Player.GetModPlayer<PrimalZergPlayer>();
                modPlayer.zergMucusMaxSpawns = value;
            } else {
                throw new UsageException("spawn cap value must be an float!");
            }
		}
	}

    public class SetSpawnCapShorcut : ModCommand
	{
		public override CommandType Type
			=> CommandType.World;

		public override string Command
			=> "PZCSpawnCap";

		public override string Usage
			=> "/PZCSpawnCap spawnCap";

		public override string Description
			=> "Change the spawn cap boost of the zerg creep concoction.";

		public override void Action(CommandCaller caller, string input, string[] args) {
            new SetSpawnCap().Action(caller, input, args);
		}
	}

}