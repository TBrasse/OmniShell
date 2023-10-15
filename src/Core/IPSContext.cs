using System.Management.Automation.Host;

namespace Core
{
	public interface IPSContext
	{
		public PSHost Host { get; set; }
		public string WorkingDir { get; set; }
	}
}