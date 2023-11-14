using System.Runtime.InteropServices;

/// <summary>A standard text fixture for NUnit</summary>
public sealed class NUnitTestFixture : IDisposable
{
	private bool initialized = false;
	private static string rhinoDir;
	private Rhino.Runtime.InProcess.RhinoCore _rhinoCore;
	internal FixtureOptions Options;

	public static NUnitTestFixture Instance;

	public NUnitTestFixture()
	{
		Instance = this;
	}

	/// <summary>Initialises the Fixture with the given options</summary>
	public void Init(FixtureOptions options)
	{
		Options = options;

		//get the correct rhino 7 installation directory
		string versionString = options.Version switch
		{
			RhinoVersion.v7 => " 7",
			RhinoVersion.v8 => "BETA",
			_ => throw new NotImplementedException("Version not implemented yet!")
		};

		string ghDir = string.Empty;
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
		{
			rhinoDir = @$"C:\Program Files\Rhino{versionString}\System";
			ghDir = @$"C:\Program Files\Rhino{versionString}\Plug-ins\Grasshopper";
		}
		else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
		{
			var contents = @$"/Applications/Rhino{versionString}.app/Contents/MacOS";
			rhinoDir = Path.Combine(contents, "MacOS", "Rhinoceros");
			ghDir = Path.Combine(contents, "Frameworks", "RhCore.framework", "Resources", "ManagedPlugIns", "GrasshopperPlugin.rhp");
		}

		Options.AssemblyPaths.Add(ghDir);
		
		Assert.True(Directory.Exists(rhinoDir), $"Rhino system dir not found: {rhinoDir}");

		Options.AssemblyPaths.Add(Path.Combine(Path.GetFullPath(Path.Combine(rhinoDir, @"..\")), "Plug-ins", "Grasshopper"));

		if (initialized)
		{
			throw new InvalidOperationException("Initialize Rhino.Inside once");
		}
		else
		{
			RhinoInside.Resolver.Initialize();
			initialized = true;
		}

		// Set path to rhino system directory
		string envPath = Environment.GetEnvironmentVariable("path");
		Environment.SetEnvironmentVariable("path", envPath + ";" + rhinoDir);

		// Start a headless rhino instance using Rhino.Inside
		StartRhino();

		// We have to load dlls on the current AppDomain manually for some reason
		AppDomain.CurrentDomain.AssemblyResolve += ResolveAssembly;
	}

	/// <summary>Starting Rhino - loading the relevant libraries</summary>
	[STAThread]
	public void StartRhino()
	{
		_rhinoCore = new Rhino.Runtime.InProcess.RhinoCore(null, Rhino.Runtime.InProcess.WindowStyle.NoWindow);
	}

	/// <summary>Resolve any missing test assemblies</summary>
	private Assembly? ResolveAssembly(object sender, ResolveEventArgs args)
	{
		foreach (string assemblyPath in Options.AssemblyPaths)
		{
			foreach (string filePath in Directory.EnumerateFiles(assemblyPath))
			{
				string fileName = Path.GetFileNameWithoutExtension(filePath).ToLowerInvariant();
				if (!args.Name.ToLowerInvariant().StartsWith(fileName)) continue;

				foreach (string extension in Options.AssemblyExtensions)
				{
					if (!filePath.ToLowerInvariant().EndsWith(extension)) continue;

					return Assembly.LoadFrom(filePath);
				}
			}
		}

		return null;
	}

	/// <summary> Disposing the context after running all the tests.
	/// It's a little bit like cleaning behind the microwave.
	/// I'm not sure if it's 100% necessary, but ...
	/// you should probably do it.</summary>
	public void Dispose()
	{
		// do nothing or...
		_rhinoCore?.Dispose();
		_rhinoCore = null;
	}

}
