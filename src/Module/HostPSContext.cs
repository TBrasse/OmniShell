﻿using Core;
using System.Management.Automation.Host;

internal class HostPSContext : IPSContext
{
	public PSHost Host { get; set; }
	public string WorkingDir { get; set; }
	public string PowershellPath { get; set; }
}