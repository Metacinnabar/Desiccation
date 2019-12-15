using Terraria;
using Terraria.ModLoader;

namespace Desiccation.Commands
{
	public class NameChangeCommand : ModCommand
	{
		public override CommandType Type
			=> CommandType.Chat;

		public override string Command
			=> "namechange";

		public override string Usage
			=> "/namechange name (under 20 characters)";

		public override string Description
			=> "Changes your ingame name";

		public override void Action(CommandCaller caller, string input, string[] args)
		{
			if (args.Length > 0)
			{
				string name = string.Join(" ", args);
				if (name.Length <= 20)
				{
					caller.Player.name = name;
					Main.NewText("Changed name to " + name);
				}
				if (name.Length > 20)
				{
					Main.NewText("You cannot have a name longer than 20 characters");
				}
			}
			else
			{
				Main.NewText("You have not specified a name");
			}
		}
	}
}