using System.Collections.Generic;
/// <summary>Allows for setting options in the Fixture.</summary>
public sealed class FixtureOptions
{

	/// <summary>The Rhino VErsion to Test</summary>
	public RhinoVersion Version { get; set; }

	/// <summary>Paths to search for assemblies (Rhino is included by default)</summary>
	public List<string> AssemblyPaths { get; set; }

	/// <summary>Potential Assembly Extensions</summary>
	public List<string> AssemblyExtensions { get; set; }

	/// <summary>Starts with Defaults</summary>
	public FixtureOptions()
	{
		AssemblyPaths = new List<string>();
		Version = RhinoVersion.v7;
		AssemblyExtensions = new List<string>() { "dll", "gha", "rhp", };
	}

	/// <summary>The Default Options</summary>
	public static FixtureOptions Default => new FixtureOptions();

}
