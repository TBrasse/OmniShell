using Core;
using System.Management.Automation;

namespace Module
{
	[Cmdlet(VerbsCommon.Get, "Config")]
	[OutputType(typeof(Configuration))]
	public class GetConfigCmd : PSCmdlet
	{
		private static IOmnishell _omnishell;
		public GetConfigCmd()
		{
			if (_omnishell == null)
			{
				_omnishell = OmnishellFactory<ModuleConfiguration>.Build<IOmnishell>();
			}
		}

		protected override void ProcessRecord()
		{
			WriteObject(_omnishell.GetConfiguration());
		}
	}
}
