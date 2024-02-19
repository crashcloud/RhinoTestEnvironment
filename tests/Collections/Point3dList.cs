using Rhino.Collections;

namespace RhinoTestEnvironment.Tests.Collections
{

	[RhinoFixture]
	public sealed class Point3dListTests
	{
		// TODO : XAxisList / YAxisList / ZAxisList

		[Test]
		public void Constructor_Test()
		{
			// Arrange
			Point3dList pointList = new();

			// Act

			// Assert
			Assert.That(pointList, Is.Empty);
			Assert.That(pointList.Capacity, Is.Zero);
		}

		[Test]
		public void Method_Test()
		{
			// Arrange
			Point3dList pointList = new();

			// Act

			// Assert
		}

	}

}
