using Desiccation.DUtils;
using Terraria;
using Terraria.ModLoader;

namespace Desiccation
{
	public class DesiccationWorld : ModWorld
	{
		public override void PreUpdate()
		{
			if (Misc.RandomFrom1OutOf(100000) && ModContent.GetInstance<DesiccationClientsideConfig>().EerieMessages)
			{
				switch (Main.rand.Next(1, 50))
				{
					case 1:
						Misc.Chat("The shadows grow...", true);
						break;
					case 2:
						Misc.Chat("No one will remember you...", true);
						break;
					case 3:
						Misc.Chat("No one will be able to help you, I'll make sure of it...", true);
						break;
					case 4:
						Misc.Chat("I could do whatever I want to you...", true);
						break;
					case 5:
						Misc.Chat("You feel the pain in your chest grow...", true);
						break;
					case 6:
						Misc.Chat("You can change the lock but I will still find you...", true);
						break;
					case 7:
						Misc.Chat("The moon is blocking out the sky and there is no place for you to hide...", true);
						break;
					case 8:
						Misc.Chat("Is everything really where it should be?", true);
						break;
					case 9:
						Misc.Chat("Wherever you go, I'll be there...", true);
						break;
					case 10:
						Misc.Chat("You are in total isolation and no one will hear your cries for help...", true);
						break;
					case 11:
						Misc.Chat("I can slip into your mind, and there is nothing you can do about it...", true);
						break;
					case 12:
						Misc.Chat("You wish to sail the seas, to escape from this island. There is no way to leave. You will forever be here, no matter how hard you try to leave...", true);
						break;
					case 13:
						Misc.Chat("One day, your vision will fade, and all you will see is me...", true);
						break;
					case 14:
						Misc.Chat("You feel your heart skip a beat as you feel a presence all around you...", true);
						break;
					case 15:
						Misc.Chat("You feel something amiss in the air around you...", true);
						break;
					case 16:
						Misc.Chat("Off in the distance, you can hear metal twisting...", true);
						break;
					case 17:
						Misc.Chat("You are floating out of your own body...", true);
						break;
					case 18:
						Misc.Chat("You can never go back...", true);
						break;
					case 19:
						Misc.Chat("The pain creeps from your ear through your throat, and down into your heart...", true);
						break;
					case 20:
						Misc.Chat("Somebody is always there, on your shoulder...", true);
						break;
					case 21:
						Misc.Chat("You cannot look away...  you are drawn in to it... drawn to your demise.", true);
						break;
					case 22:
						Misc.Chat("You feel as if you are spiraling down an open trapdoor...", true);
						break;
					case 23:
						Misc.Chat("Your own mind begins to trap you inside of it...", true);
						break;
					case 24:
						Misc.Chat("Your path has been chosen, and there is no escape...", true);
						break;
					case 25:
						Misc.Chat("You know I’m still here, always watching...", true);
						break;
					case 26:
						Misc.Chat("I’ve seen everything you’ve done, everything...", true);
						break;
					case 27:
						Misc.Chat("Look behind you, look up, you feel the crawling innocence falling down your throat...", true);
						break;
					case 28:
						Misc.Chat("Ever wondered whether there’s someone who sends these messages?", true);
						break;
					case 29:
						Misc.Chat("Where are you going...?  ...Come back...", true);
						break;
					case 30:
						Misc.Chat("You hear screaming from the caves below you...", true);
						break;
					case 31:
						Misc.Chat("You hear the rattling of bones coming from all around you...", true);
						break;
					case 32:
						Misc.Chat("You are unable to sleep...", true);
						break;
					case 33:
						Misc.Chat("An unearthly, alien feeling grows inside of you...", true);
						break;
					case 34:
						Misc.Chat("You know nobody will be there to save you...", true);
						break;
					case 35:
						Misc.Chat("Everything around you turns dark...", true);
						break;
					case 36:
						Misc.Chat("An eerie silence fills your ears...", true);
						break;
					case 37:
						Misc.Chat("You feel an ambient shaking from below...", true);
						break;
					case 38:
						Misc.Chat("It feels so wrong...   ...but could it really be right?", true);
						break;
					case 39:
						Misc.Chat("Your mind stops thinking, and you stop breathing, if only for a brief moment...", true);
						break;
					case 40:
						Misc.Chat("When the clock struck midnight, the moon disappeared, and everything went quiet...", true);
						break;
					case 41:
						Misc.Chat("They say those who go there come back deprived of all life...", true);
						break;
					case 42:
						Misc.Chat("It appeared in the sky and cast a shadow upon all life down on the surface...", true);
						break;
					case 43:
						Misc.Chat("Let them keep it safe. They won’t let anyone through in one piece.", true);
						break;
					case 44:
						Misc.Chat("It belongs to the cult. They protect it well, they would even shed blood for it.", true);
						break;
					case 45:
						Misc.Chat("The crystals call your name, screaming in agony...", true);
						break;
					case 46:
						Misc.Chat("The desiccation will suck you down beneath, down to the other side. It will deprive you of life, it will change everything you love. You cannot overcome it, even if you try.", true);
						break;
					case 47:
						Misc.Chat("None of them asked for it. It was not meant to happen. It was simply a rule rebelliously broken. But not now, not anymore. Now it is much more.", true);
						break;
					case 48:
						Misc.Chat("When held up to the sky, the lens will bring terror to all, and take life away from everything.", true);
						break;
					case 49:
						Misc.Chat("The shard holds the power, the death, and...    ...the Desiccation.", true);
						break;
					case 50:
						Misc.Chat("You are short of time...", true);
						break;
				}
			}
		}
	}
}