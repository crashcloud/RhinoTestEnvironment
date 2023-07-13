public class RhinoFixtureAttribute : NUnit.Framework.TestFixtureAttribute
{

	public RhinoFixtureAttribute()
	{
		if (NUnitTestFixture.Instance is null)
		{
			NUnitTestFixture.Instance = new();
			NUnitTestFixture.Instance.Init(FixtureOptions.Default);
		}
	}
}