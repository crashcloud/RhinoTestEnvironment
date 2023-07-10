using Rhino.Collections;

namespace RhinoTestEnvironment.Tests.Collections
{

	public sealed class CurveListTests
	{

		[Test]
		public void Constructor_Test()
		{
			// Arrange
			CurveList curveList = new();

			// Assert
			Assert.That(curveList, expression: Is.Empty);
			Assert.That(curveList.Count, Is.Zero);
			Assert.That(curveList.Capacity, Is.Zero);
			Assert.That(curveList.NullCount, Is.Zero);
		}

		[Test]
		public void Method_Test()
		{
			// Arrange
			CurveList curveList = new();

			// Act
			curveList.Sort();

			// Assert
			Assert.That(curveList, expression: Is.Empty);
			Assert.That(curveList.Count, Is.Zero);
			Assert.That(curveList.Capacity, Is.Zero);
			Assert.That(curveList.NullCount, Is.Zero);
		}

	}

}
