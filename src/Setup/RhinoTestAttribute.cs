/// <summary>Injects Rhino Assemblies into the AppDomain of tests</summary>
public class RhinoFixtureAttribute
{

	public RhinoFixtureAttribute()
	{
		Init(null);
	}

	/// <summary>Initialises the Rhino Environment</summary>
	/// <param name="options"></param>
	protected static void Init(FixtureOptions options)
	{
		if (NUnitTestFixture.Instance is null)
		{
			options ??= FixtureOptions.Default;

			NUnitTestFixture.Instance = new();
			NUnitTestFixture.Instance.Init(options);
		}
	}
}