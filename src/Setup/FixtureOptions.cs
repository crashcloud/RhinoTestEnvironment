public sealed class FixtureOptions
{
	public RhinoVersion Version { get; set; }
	public bool IncludeGrasshoper { get; set; }
	public string[] AssemblyPaths { get; set; }
}

public enum RhinoVersion
{
	v7,
	v8,
	WIP
}
