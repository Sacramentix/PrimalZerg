using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace PrimalZerg.Items
{
	public class SwarmCreepConcoction : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Swarm creep concoction"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("increase the spawn rate and the spawn cap");
		}

		public override void SetDefaults() 
		{
			item.width = 24;
            item.height = 32;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.NPCDeath13;
            item.maxStack = 30;
            item.consumable = true;
            item.rare = ItemRarityID.LightPurple;
            item.value = Item.buyPrice(gold: 1);
            item.buffType = BuffType<Buffs.ZergCreep>(); //Specify an existing buff to be applied when used.
            item.buffTime = 36000; //The amount of time the buff declared in item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe1 = new ModRecipe(mod);
			recipe1.AddIngredient(ItemID.BottledWater, 1);
			recipe1.AddIngredient(ItemID.Gel, 6);
			recipe1.AddIngredient(ItemID.SoulofNight, 6);
			recipe1.AddIngredient(ItemID.Ichor, 6);
			recipe1.AddTile(TileID.Bottles);
			//recipe1.AddTile(TileID.AlchemyTable);
			recipe1.alchemy = true;
			recipe1.SetResult(this);
			recipe1.AddRecipe();

			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.BottledWater, 1);
			recipe2.AddIngredient(ItemID.Gel, 6);
			recipe2.AddIngredient(ItemID.SoulofNight, 6);
			recipe2.AddIngredient(ItemID.CursedFlame, 6);
			recipe2.alchemy = true;
			//recipe2.AddTile(TileID.AlchemyTable);
			recipe2.AddTile(TileID.Bottles);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}
	}
}