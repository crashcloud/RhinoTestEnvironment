using Rhino.Collections;

namespace RhinoTestEnvironment.Tests.Collections
{

	public sealed class ArchivableDictionaryTests
	{

		[Test]
		public void Constructor_Test()
		{
			// Arrange
			ArchivableDictionary archDict = new();

			// Assert
			Assert.That(archDict.Count, Is.Zero);
			Assert.That(archDict.Keys, Is.Empty);
			Assert.That(archDict.Values, Is.Empty);
		}

		[Test]
		public void Set_Test()
		{
			/* System.Drawing.Font?
			// Arrange
			ArchivableDictionary archDict = new();

			// Act
			archDict.Set(nameof(Boolean), true);

			// Assert
			Assert.That(archDict.Count, Is.Not.Zero);
			Assert.That(archDict.Keys, Is.Not.Empty);
			Assert.That(archDict.Values, Is.Not.Empty);
			*/
		}

	}

}
