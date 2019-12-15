using Desiccation.DUtils;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Desiccation
{
	public class DesiccationWorld : ModWorld
	{
		public override void PreUpdate()
		{
			if (Main.anglerQuestFinished)
			{
				Main.AnglerQuestSwap();
			}

			//Eerie Messages
			if (Misc.RandomInt(1, 100000) == 1)
			{
				const int messageCount = 50;
				Color color = Color.White;
				if (Main.netMode == NetmodeID.SinglePlayer)
				{
					switch (Main.rand.Next(messageCount))
					{
						case 0:
							Main.NewText("You are short of time...");
							break;
						case 1:
							Main.NewText("The shadows grow...");
							break;
						case 2:
							Main.NewText("No one will remeber you...");
							break;
						case 3:
							Main.NewText("No one will be able to help you, i'll make sure of it...");
							break;
						case 4:
							Main.NewText("I could do whatever I want to you...");
							break;
						case 5:
							Main.NewText("You feel the pain in your chest grow...");
							break;
						case 6:
							Main.NewText("You can change the lock but I will still find you...");
							break;
						case 7:
							Main.NewText("The moon is blocking out the sky and there is no place for you to hide...");
							break;
						case 8:
							Main.NewText("Is everything really where it should be?");
							break;
						case 9:
							Main.NewText("Wherever you go, i'll be there...");
							break;
						case 10:
							Main.NewText("You are in total isolation and no one will hear your cries for help...");
							break;
						case 11:
							Main.NewText("I can slip into your mind, and there is nothing you can do about it...");
							break;
						case 12:
							Main.NewText("You wish to sail the seas, to escape from this island. There is no way to leave. You will forever be here, no matter how hard you try to leave...");
							break;
						case 13:
							Main.NewText("One day, your vision will fade, and all you will see is me...");
							break;
						case 14:
							Main.NewText("You feel your heart skip a beat as you feel a presence all around you...");
							break;
						case 15:
							Main.NewText("You feel something amiss in the air around you...");
							break;
						case 16:
							Main.NewText("Off in the distance, you can hear metal twisting...");
							break;
						case 17:
							Main.NewText("You are floating out of your own body...");
							break;
						case 18:
							Main.NewText("You can never go back...");
							break;
						case 19:
							Main.NewText("The pain creeps from your ear through your throat, and down into your heart...");
							break;
						case 20:
							Main.NewText("Somebody is always there, on your shoulder...");
							break;
						case 21:
							Main.NewText("You cannot look away...  you are drawn in to it... drawn to your demise.");
							break;
						case 22:
							Main.NewText("You feel as if you are spiraling down an open trapdoor...");
							break;
						case 23:
							Main.NewText("Your own mind begins to trap you inside of it...");
							break;
						case 24:
							Main.NewText("Your path has been chosen, and there is no escape...");
							break;
						case 25:
							Main.NewText("You know I’m still here, always watching...");
							break;
						case 26:
							Main.NewText("I’ve seen everything you’ve done, everything...");
							break;
						case 27:
							Main.NewText("Look behind you, look up, you feel the crawling innocence falling down your throat...");
							break;
						case 28:
							Main.NewText("Ever wondered whether there’s someone who sends these messages?");
							break;
						case 29:
							Main.NewText("Where are you going...?  ...come back...");
							break;
						case 30:
							Main.NewText("You hear screaming from the caves below you...");
							break;
						case 31:
							Main.NewText("You hear the rattling of bones coming from all around you...");
							break;
						case 32:
							Main.NewText("You are unable to sleep...");
							break;
						case 33:
							Main.NewText("An unearthly, alien feeling grows inside of you...");
							break;
						case 34:
							Main.NewText("You know nobody will be there to save you...");
							break;
						case 35:
							Main.NewText("Everything around you turns dark...");
							break;
						case 36:
							Main.NewText("An eerie silence fills your ears...");
							break;
						case 37:
							Main.NewText("You feel an ambient shaking from below...");
							break;
						case 38:
							Main.NewText("It feels so wrong...   ...but could it really be right?");
							break;
						case 39:
							Main.NewText("Your mind stops thinking, and you stop breathing, if only for a brief moment...");
							break;
						case 40:
							Main.NewText("When the clock struck midnight, the moon disappeared, and everything went quiet...");
							break;
						case 41:
							Main.NewText("They say those who go there come back deprived of all life...");
							break;
						case 42:
							Main.NewText("It appeared in the sky and cast a shadow upon all life down on the surface...");
							break;
						case 43:
							Main.NewText("Let them keep it safe. They won’t let anyone through in one piece.");
							break;
						case 44:
							Main.NewText("It belongs to the cult. They protect it well, they would even shed blood for it.");
							break;
						case 45:
							Main.NewText("The crystals call your name, screaming in agony...");
							break;
						case 46:
							Main.NewText("The desiccation will suck you down beneath, down to the other side. It will deprive you of life, it will change everything you love. You cannot overcome it, even if you try.");
							break;
						case 47:
							Main.NewText("None of them asked for it. It was not meant to happen. It was simply a rule rebelliously broken. But not now, not anymore. Now it is much more.");
							break;
						case 48:
							Main.NewText("When held up to the sky, the lens will bring terror to all, and take life away from everything.");
							break;
						default:
							Main.NewText("The shard holds the power, the death, and...    ...the Desiccation.");
							break;
					}
				}
				else if (Main.netMode != NetmodeID.SinglePlayer)
				{
					switch (Main.rand.Next(messageCount))
					{
						case 0:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("You are short of time..."), color);
							break;
						case 1:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The shadows grow..."), color);
							break;
						case 2:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("No one will remeber you..."), color);
							break;
						case 3:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("No one will be able to help you, i'll make sure of it..."), color);
							break;
						case 4:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("I could do whatever I want to you..."), color);
							break;
						case 5:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("You feel the pain in your chest grow..."), color);
							break;
						case 6:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("You can change the lock but I will still find you..."), color);
							break;
						case 7:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The moon is blocking out the sky and there is no place for you to hide..."), color);
							break;
						case 8:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Is everything really where it should be?"), color);
							break;
						case 9:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Wherever you go, i'll be there..."), color);
							break;
						case 10:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("You are in total isolation and no one will hear your cries for help..."), color);
							break;
						case 11:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("I can slip into your mind, and there is nothing you can do about it..."), color);
							break;
						case 12:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("You wish to sail the seas, to escape from this island. There is no way to leave. You will forever be here, no matter how hard you try to leave..."), color);
							break;
						case 13:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("One day, your vision will fade, and all you will see is me..."), color);
							break;
						case 14:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("You feel your heart skip a beat as you feel a presence all around you..."), color);
							break;
						case 15:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("You feel something amiss in the air around you..."), color);
							break;
						case 16:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Off in the distance, you can hear metal twisting..."), color);
							break;
						case 17:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("You are floating out of your own body..."), color);
							break;
						case 18:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("You can never go back..."), color);
							break;
						case 19:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The pain creeps from your ear through your throat, and down into your heart..."), color);
							break;
						case 20:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Somebody is always there, on your shoulder..."), color);
							break;
						case 21:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("You cannot look away...  you are drawn in to it... drawn to your demise."), color);
							break;
						case 22:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("You feel as if you are spiraling down an open trapdoor..."), color);
							break;
						case 23:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your own mind begins to trap you inside of it..."), color);
							break;
						case 24:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your path has been chosen, and there is no escape..."), color);
							break;
						case 25:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("You know I’m still here, always watching..."), color);
							break;
						case 26:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("I’ve seen everything you’ve done, everything..."), color);
							break;
						case 27:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Look behind you, look up, you feel the crawling innocence falling down your throat..."), color);
							break;
						case 28:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Ever wondered whether there’s someone who sends these messages?"), color);
							break;
						case 29:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Where are you going...?  ...come back..."), color);
							break;
						case 30:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("You hear screaming from the caves below you..."), color);
							break;
						case 31:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("You hear the rattling of bones coming from all around you..."), color);
							break;
						case 32:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("You are unable to sleep..."), color);
							break;
						case 33:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("An unearthly, alien feeling grows inside of you..."), color);
							break;
						case 34:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("You know nobody will be there to save you..."), color);
							break;
						case 35:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Everything around you turns dark..."), color);
							break;
						case 36:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("An eerie silence fills your ears..."), color);
							break;
						case 37:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("You feel an ambient shaking from below..."), color);
							break;
						case 38:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("It feels so wrong...   ...but could it really be right?"), color);
							break;
						case 39:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Your mind stops thinking, and you stop breathing, if only for a brief moment..."), color);
							break;
						case 40:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("When the clock struck midnight, the moon disappeared, and everything went quiet..."), color);
							break;
						case 41:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("They say those who go there come back deprived of all life..."), color);
							break;
						case 42:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("It appeared in the sky and cast a shadow upon all life down on the surface..."), color);
							break;
						case 43:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("Let them keep it safe. They won’t let anyone through in one piece."), color);
							break;
						case 44:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("It belongs to the cult. They protect it well, they would even shed blood for it."), color);
							break;
						case 45:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The crystals call your name, screaming in agony..."), color);
							break;
						case 46:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The desiccation will suck you down beneath, down to the other side. It will deprive you of life, it will change everything you love. You cannot overcome it, even if you try."), color);
							break;
						case 47:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("None of them asked for it. It was not meant to happen. It was simply a rule rebelliously broken. But not now, not anymore. Now it is much more."), color);
							break;
						case 48:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("When held up to the sky, the lens will bring terror to all, and take life away from everything."), color);
							break;
						default:
							NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The shard holds the power, the death, and...    ...the Desiccation."), color);
							break;
					}
				}
			}
		}
	}
}