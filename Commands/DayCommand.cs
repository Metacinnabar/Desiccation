using Terraria;
using Terraria.ModLoader;

namespace Desiccation.Commands
{
	public class DayCommand : ModCommand
	{
		public override CommandType Type
			=> CommandType.World;

		public override string Command
			=> "day";

		public override string Usage
			=> "/day";

		public override string Description
			=> "Changes the time to day.";

		public override void Action(CommandCaller caller, string input, string[] args)
		{
			Main.dayTime = true;
			Main.time = 0;
		}
	}
}