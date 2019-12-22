﻿using Desiccation.DUtils;
using Terraria;
using Terraria.ModLoader;

namespace Desiccation.Commands
{
	public class NWorldNameCommand : ModCommand
	{
		public override CommandType Type
			=> CommandType.Chat;

		public override string Command
			=> "worldname";

		public override string Usage
			=> "/worldname NEW NAME (under 20 characters)";

		public override string Description
			=> "Changes your ingame world name";

		public override void Action(CommandCaller caller, string input, string[] args)
		{
			if (Misc.IsPlayerServerOwner(PlayerData.MyPlayer))
			{
				if (args.Length > 0)
				{
					string name = string.Join(" ", args);
					if (name.Length <= 20)
					{
						Misc.Chat($"Changed {Main.worldName}'s name to '{name}'!");
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