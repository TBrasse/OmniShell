using System;
using Omnishell.Core.Styles;

namespace Omnishell.Core
{
	internal class ConsolePrinter : IConsolePrinter
	{
		public void Print(FormatedStyle formatedSegment)
		{
			ConsoleColor foregroundColor = Console.ForegroundColor;
			ConsoleColor backgroundColor = Console.BackgroundColor;

			PrintConsoleString(formatedSegment.Prefix);
			PrintConsoleString(formatedSegment.Center);
			PrintConsoleString(formatedSegment.Suffix);

			Console.ForegroundColor = foregroundColor;
			Console.BackgroundColor = backgroundColor;
		}

		public void PrintConsoleString(ConsoleString consoleString)
		{
			if (consoleString == null)
			{
				return;
			}
			Console.ForegroundColor = consoleString.Foreground;
			Console.BackgroundColor = consoleString.Background;
			if (consoleString.String != null)
			{
				Console.Write(consoleString.String);
			}
		}
	}
}