using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;
namespace PrimalZerg
{
	internal enum PrimalZergMessageType : byte
	{
		ChangeZergMucusSpawnRate,
		ChangeZergMucusMaxSpawns
	}
	public class PrimalZerg : Mod
	{
		public static bool showSpawnInfo;
		public override void HandlePacket(BinaryReader reader, int whoAmI) {
			PrimalZergMessageType msgType = (PrimalZergMessageType)reader.ReadByte();
			switch (msgType) {
				case PrimalZergMessageType.ChangeZergMucusSpawnRate:
					byte playernumber = reader.ReadByte();
					PrimalZergPlayer primalZergPlayer = Main.player[playernumber].GetModPlayer<PrimalZergPlayer>();
					primalZergPlayer.zergMucusSpawnRate = reader.ReadDouble();
					// Unlike SyncPlayer, here we have to relay/forward these changes to all other connected clients
					if (Main.netMode == NetmodeID.Server) {
						var packet = GetPacket();
						packet.Write((byte)PrimalZergMessageType.ChangeZergMucusSpawnRate);
						packet.Write(playernumber);
						packet.Write(primalZergPlayer.zergMucusSpawnRate );
						packet.Send(-1, playernumber);
					}
					break;
				case PrimalZergMessageType.ChangeZergMucusMaxSpawns:
					playernumber = reader.ReadByte();
					primalZergPlayer = Main.player[playernumber].GetModPlayer<PrimalZergPlayer>();
					primalZergPlayer.zergMucusMaxSpawns = reader.ReadDouble();
					// Unlike SyncPlayer, here we have to relay/forward these changes to all other connected clients
					if (Main.netMode == NetmodeID.Server) {
						var packet = GetPacket();
						packet.Write((byte)PrimalZergMessageType.ChangeZergMucusSpawnRate);
						packet.Write(playernumber);
						packet.Write(primalZergPlayer.zergMucusMaxSpawns);
						packet.Send(-1, playernumber);
					}
					break;
			}
		}
	}
}