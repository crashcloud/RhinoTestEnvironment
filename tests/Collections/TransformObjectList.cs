using Rhino.Collections;

namespace RhinoTestEnvironment.Tests.Collections
{

	public partial class TransformObjectListTests
	{

		[Test]
		public void Constructor_Test()
		{
			// Arrange
			TransformObjectList tranObjectList = new();

			// Assert
			Assert.That(tranObjectList, Is.Empty);
			Assert.That(tranObjectList.Count, Is.Zero);
		}

	}

}
