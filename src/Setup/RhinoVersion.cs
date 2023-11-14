
/// <summary>The available Rhino Versions</summary>
[Flags]
public enum RhinoVersion
{

	/// <summary>Unset</summary>
	None = 0,

	/// <summary>Rhino Version 7</summary>
	v7,

	/// <summary>Rhino Version 8</summary>
	v8,
	
	/// <summary>Rhino WIP Version</summary>
	WIP = int.MaxValue

}