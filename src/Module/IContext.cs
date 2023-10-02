using System.Management.Automation.Host;

internal interface IPSContext
{
	public PSHost Host { get; set; }
	public string WorkingDir { get; set; }
}