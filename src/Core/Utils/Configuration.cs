﻿using Core.Painter;

namespace Core.Utils;

public class Configuration
{
	public string Version { get; set; }
	public string Switch { get; set; }
	public Dictionary<string, Profile> Profiles { get; set; }
	public Dictionary<string, Format> Formats { get; set; }
}