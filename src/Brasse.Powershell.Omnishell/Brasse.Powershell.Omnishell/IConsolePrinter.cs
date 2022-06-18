using Omnishell.Core.Styles;

namespace Omnishell.Core
{
	internal interface IConsolePrinter
	{
		void Print(FormatedStyle formatedSegment);
	}
}