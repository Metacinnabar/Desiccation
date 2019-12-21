using Desiccation.DUtils;
using Terraria;
using Terraria.ModLoader;

namespace Desiccation.Commands
{
	public class PlayerNameCommand : ModCommand
	{
		public override CommandType Type
			=> CommandType.Chat;

		public override string Command
			=> "playername";

		public override string Usage
			=> "/playername NEW NAME (under 20 characters)";

		public override string Description
			=> "Changes your ingame player name";

		public override void Action(CommandCaller caller, string input, string[] args)
		{
			if (ModContent.GetInstance<DesiccationGlobalConfig>().PlayerNameChange)
			{
				if (args.Length > 0)
				{
					string name = string.Join(" ", args);
					if (name.Length <= 20)
					{
						Misc.Chat($"Changed {caller.Player.name}'s name to {name}!");
						caller.Player.name = name;
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
				Main.NewText("ERROR: The server host has turned off player name changing via config.");
			}
		}
	}
}