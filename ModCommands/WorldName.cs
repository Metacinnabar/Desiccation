using Desiccation.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Desiccation.ModCommands
{
	public class NWorldName : ModCommand
	{
		public override CommandType Type => CommandType.Chat | CommandType.World;
		public override string Command => "worldname";
		public override string Usage => "/worldname NEW NAME (under 20 characters)";
		public override string Description => "Changes your ingame world name";

		public override void Action(CommandCaller caller, string input, string[] args)
		{
			if (NetData.IsPlayerServerOwner(PlayerData.MyPlayer))
			{
				if (args.Length > 0)
				{
					string name = string.Join(" ", args);
					if (name.Length <= 20)
					{
						DUtils.Chat($"Changed {Main.worldName}'s name to '{name}'!", true, Color.CornflowerBlue.R, Color.CornflowerBlue.G, Color.CornflowerBlue.B);
						Main.worldName = name;
					}
					if (name.Length > 20)
					{
						Main.NewText("ERROR: You cannot have a name longer than 20 characters.");
					}
				}
				else
				{
					Main.NewText("ERROR: You have not specified a name.");
				}
			}
			else
			{
				Main.NewText("ERROR: You are not the server host.");
			}
		}
	}
}