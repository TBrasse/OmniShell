using Core.Painter;
using Core.Utils;

namespace Core;

public interface IConfigProvider
{
	void ReadAndSetFormats();
	void ReadAndSetProfile();
}