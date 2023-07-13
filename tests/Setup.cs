[SetUpFixture]
public static class TestSetup
{

	[OneTimeSetUp]
	public static void Setup()
	{
		NUnitTestFixture fixture = new NUnitTestFixture();
		fixture.Init(new FixtureOptions());
	}

}