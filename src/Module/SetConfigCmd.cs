using Core;
using System.Management.Automation;

namespace Module
{
	[Cmdlet(VerbsCommon.Set, "Config")]
	public class SetConfigCmd : PSCmdlet
	{
		[Parameter(Mandatory = true)]
		public Configuration Configuration { get; set; }

		private static IOmnishell _omnishell;
		public SetConfigCmd()
		{
			if (_omnishell == null)
			{
				_omnishell = OmnishellFactory<ModuleConfiguration>.Build<IOmnishell>();
			}
		}

		protected override void ProcessRecord()
		{
			_omnishell.SetConfiguration(Configuration);
		}
	}
}
