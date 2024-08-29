using Core.Shell;
using System.Runtime.InteropServices;

namespace Core.Segments;

public class PlatformSegment : AbstractSegment
{
	private string Expression = "switch([Environment]::OSVersion.Platform){ 'Win32NT'{''} 'Unix'{''} 'MacOSX'{''}}";

	public PlatformSegment()
	{
		Name = "platform";
	}

	public override bool Resolve(IShellExecutor shell)
	{
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			Value = "";
		}
		else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
		{
			Value = "";
		}
		else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
		{
			Value = "";
		}
		else
		{
			Value = "?";
			return false;
		}
		return true;
		//PowershellResult result = shell.Execute(Expression);
		//Value = result.Value;
		//return result.Successfull && !string.IsNullOrEmpty(result.Value);
	}
}
