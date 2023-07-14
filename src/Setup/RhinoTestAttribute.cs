/// <summary>Injects Rhino Assemblies into the AppDomain of tests</summary>
public class RhinoFixtureAttribute : NUnit.Framework.TestFixtureAttribute
{

	public RhinoFixtureAttribute()
	{
		Init(null);
	}

	protected static void Init(FixtureOptions? options)
	{
		if (NUnitTestFixture.Instance is null)
		{
			options ??= FixtureOptions.Default;

			NUnitTestFixture.Instance = new();
			NUnitTestFixture.Instance.Init(options);
		}
	}
}