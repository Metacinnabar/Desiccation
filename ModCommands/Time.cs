using Terraria;
using Terraria.ModLoader;

namespace Desiccation.ModCommands
{
	public class Time : ModCommand
	{
		public override CommandType Type
			=> CommandType.World;

		public override string Command
			=> "time";

		public override string Usage
			=> "/time time (from 0 - 54000)";

		public override string Description
			=> "Changes the time to the specified arguments";

		public override void Action(CommandCaller caller, string input, string[] args)
		{
			Main.time = int.Parse(args[0]);
		}
	}
}