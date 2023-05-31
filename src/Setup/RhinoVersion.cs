
/// <summary>The available Rhino Versions</summary>
[Flags]
public enum RhinoVersion
{

	/// <summary>Unset</summary>
	Unset = 0,

	/// <summary>Rhino Version 7</summary>
	v7 = 1 << 0,

	/// <summary>Rhino Version 8</summary>
	v8 = 1 << 1,

	/// <summary>Rhino WIP Version</summary>
	WIP = 1 << 2

}
