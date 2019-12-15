using Terraria;
using Terraria.ModLoader;

namespace Desiccation.Commands
{
	public class Nightommand : ModCommand
	{
		public override CommandType Type
			=> CommandType.World;

		public override string Command
			=> "night";

		public override string Usage
			=> "/night";

		public override string Description
			=> "Changes the time to night.";

		public override void Action(CommandCaller caller, string input, string[] args)
		{
			Main.time = 54000;
		}
	}
}