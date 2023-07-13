public sealed class RhinoTestAttribute : NUnit.Framework.TestAttribute
{

	public RhinoTestAttribute()
	{
		if (NUnitTestFixture.Instance is null)
		{
			NUnitTestFixture.Instance = new();
			NUnitTestFixture.Instance.Init(FixtureOptions.Default);
		}
	}

}

public class RhinoTheoryAttribute : NUnit.Framework.TheoryAttribute
{

	public RhinoTheoryAttribute()
	{
		if (NUnitTestFixture.Instance is null)
		{
			NUnitTestFixture.Instance = new();
			NUnitTestFixture.Instance.Init(FixtureOptions.Default);
		}
	}
}

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

public class RhinoOneTimeSetUpAttribute : NUnit.Framework.OneTimeSetUpAttribute
{

	public RhinoOneTimeSetUpAttribute()
	{
		if (NUnitTestFixture.Instance is null)
		{
			NUnitTestFixture.Instance = new();
			NUnitTestFixture.Instance.Init(FixtureOptions.Default);
		}
	}
}
