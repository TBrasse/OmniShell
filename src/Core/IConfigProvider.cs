using Core.Painter;
using Core.Utils;

namespace Core;

public interface IConfigProvider
{
	Dictionary<string, Format> GetFormats(Configuration configuration, Profile profile);
	Profile GetProfile(Configuration configuration);
}