public class RhinoFixtureAttribute : NUnit.Framework.TestFixtureAttribute
{

	public RhinoFixtureAttribute(FixtureOptions options = null)
	{
		if (NUnitTestFixture.Instance is null)
		{
			if (options is null)
   			{
      				options = FixtureOptions.Default;
      			}
	 
			NUnitTestFixture.Instance = new();
			NUnitTestFixture.Instance.Init(options);
		}
	}
}
