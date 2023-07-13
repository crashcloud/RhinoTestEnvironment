/// <summary>A standard text fixture for NUnit</summary>
public sealed class NUnitTestFixture : IDisposable
{
	private bool initialized = false;
	private static string rhinoDir;
	private Rhino.Runtime.InProcess.RhinoCore _rhinoCore;
	FixtureOptions _options;

	public static NUnitTestFixture Instance;

	public NUnitTestFixture()
	{
		Instance = this;
	}

	/// <summary>Initialises the Fixture with the given options</summary>
	public void Init(FixtureOptions options)
	{
		_options = options;

		//get the correct rhino 7 installation directory
		string versionString = options.Version switch
		{
			RhinoVersion.v7 => "7",
			RhinoVersion.v8 => "8 WIP",
			_ => throw new NotImplementedException("Version not implemented yet!")
		};
		rhinoDir = $"C:\\Program Files\\Rhino {versionString}\\System";
		Assert.True(Directory.Exists(rhinoDir), $"Rhino system dir not found: {rhinoDir}");

		// Make sure we are running the tests as 64x
		Assert.True(Environment.Is64BitProcess, "Tests must be run as x64");

		_options.AssemblyPaths.Add(Path.Combine(Path.GetFullPath(Path.Combine(rhinoDir, @"..\")), "Plug-ins", "Grasshopper"));

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
		foreach (string assemblyPath in _options.AssemblyPaths)
		{
			foreach (string filePath in Directory.EnumerateFiles(assemblyPath))
			{
				string fileName = Path.GetFileNameWithoutExtension(filePath).ToLowerInvariant();
				if (!args.Name.ToLowerInvariant().StartsWith(fileName)) continue;

				foreach (string extension in _options.AssemblyExtensions)
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
