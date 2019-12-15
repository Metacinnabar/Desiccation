using Desiccation.Dusts;
using Desiccation.Items.Miner;
using Desiccation.Projectiles.Miner;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Desiccation.NPCs.TownNPCs
{
	[AutoloadHead]
	public class Miner : ModNPC
	{
		public override string Texture => "Desiccation/NPCs/TownNPCs/Miner";

		public override bool Autoload(ref string name)
		{
			name = "Miner";
			return mod.Properties.Autoload;
		}

		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 700;
			NPCID.Sets.AttackType[npc.type] = 0;
			NPCID.Sets.AttackTime[npc.type] = 90;
			NPCID.Sets.AttackAverageChance[npc.type] = 30;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}

		public override void SetDefaults()
		{
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 10;
			npc.defense = 15;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			int num = npc.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, ModContent.DustType<LightDust>());
			}
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (!player.active)
				{
					continue;
				}
				if (money >= 10000 && NPC.AnyNPCs(NPCID.Merchant) == true)
				{
					foreach (Item item in player.inventory)
					{
						if (item.type == ItemID.TungstenPickaxe || item.type == ItemID.SilverPickaxe)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		public override string TownNPCName()
		{
			switch (WorldGen.genRand.Next(18))
			{
				case 0:
					return "Barry";
				case 1:
					return "Benjamin";
				case 2:
					return "Clyde";
				case 3:
					return "Dennis";
				case 4:
					return "Dusty";
				case 5:
					return "Frank";
				case 6:
					return "Gus";
				case 7:
					return "Harold";
				case 8:
					return "Jimmy";
				case 9:
					return "Larry";
				case 10:
					return "Monty";
				case 11:
					return "Nicholas";
				case 12:
					return "Oliver";
				case 13:
					return "Patrick";
				case 14:
					return "Richard";
				case 15:
					return "Sam";
				case 16:
					return "Truman";
				default:
					return "William";
			}
		}

		public override string GetChat()
		{
			WeightedRandom<string> chat = new WeightedRandom<string>();
			string world = Main.worldName;
			int demolitionistName = NPC.FindFirstNPC(NPCID.Demolitionist);
			int clothierName = NPC.FindFirstNPC(NPCID.Clothier);
			int goblinTinkererName = NPC.FindFirstNPC(NPCID.GoblinTinkerer);
			int mechanicName = NPC.FindFirstNPC(NPCID.Mechanic);
			if (Main.dayTime)
			{
				chat.Add("The slimes you see up here come in different, more vicious colors underground.");
				chat.Add("Ever wondered what it's like to be a coal miner? I'd tell you, but there's no coal in " + world + ".");
				chat.Add("My mining gear is the cream of the crop, the best you'll find, and it hasn't been tested yet. Don't tell anyone.");
			}
			if (!Main.dayTime)
			{
				chat.Add("The surface is overrun with those zombies and demon eyes at night. That's why I like to stay underground during the night.");
				chat.Add("I wish I could go to the moon and mine up whatever's up there. That would be nice."); //(The mod will contain an achievement for making the miner a house on the moon and getting him to live in it));
			}
			if (NPC.AnyNPCs(NPCID.Demolitionist) == true)
			{
				chat.Add(demolitionistName + " is a wonderful friend, but his method of mining is too sloppy and dangerous.");
			}
			if (NPC.AnyNPCs(NPCID.Clothier) == true)
			{
				chat.Add(clothierName + " keeps trying to sell me clean clothes. Doesn't he know they'll just get dusty again?");
			}
			if (NPC.AnyNPCs(NPCID.GoblinTinkerer) == true)
			{
				chat.Add("I asked " + goblinTinkererName + " to make me a mining gadget. I ended up with a pickaxe-mining helmet hybrid.");
			}
			if (NPC.AnyNPCs(NPCID.Mechanic) == true)
			{
				chat.Add(mechanicName + " knows a thing or two about those traps in the caves. I don't though. I just fall for them.");
			}
			chat.Add("Why bother trying to look good when you're just going to get covered in dust?");
			chat.Add("Watch out for fool's gold. Trust me, sometimes I can't tell the difference.");
			chat.Add("I've heard tales about this teleporting wizard in the caverns. Im glad I havent seen him yet."); //Reference [Tim]
																													   //chat.Add("This message has a weight of 0.1, meaning it appears 10 times as rare.", 0.1);
			return chat; //chat is implicitly cast to a string. You can also do "return chat.Get();" if that makes you feel better
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{
			button = Language.GetTextValue("LegacyInterface.28");
			button2 = "Fasten Up";
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				shop = true;
			}
			if (!firstButton)
			{
				// If the 2nd button is pressed, open the inventory...
				Main.playerInventory = true;
				// remove the chat window...
				Main.npcChatText = "";
				// and start an instance of our UIState.
				ModContent.GetInstance<Desiccation>().MinerUserInterface.SetState(new UI.MinerLightUI());
				// Note that even though we remove the chat window, Main.LocalPlayer.talkNPC will still be set correctly and we are still technically chatting with the npc.
			}
		}

		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.item[nextSlot].SetDefaults(ItemType<Chisel>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<Pan>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(88);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(410);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(411);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(8);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(84);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(282);
			nextSlot++;
			if (!Main.dayTime)
			{
				shop.item[nextSlot].SetDefaults(ItemType<OverbrightTorch>());
				nextSlot++;
			}
			if (Main.bloodMoon)
			{
				shop.item[nextSlot].SetDefaults(2322);
				nextSlot++;
				shop.item[nextSlot].SetDefaults(296);
				nextSlot++;
			}
			if (Main.eclipse)
			{
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<LightPickaxe>());
				nextSlot++;
			}
		}

		public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), ItemID.MiningHelmet, 1);
		}

		public override bool CanGoToStatue(bool toKingStatue)
		{
			return true;
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 10;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ModContent.ProjectileType<MinerProjectile>();
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}

		public
	}
}
