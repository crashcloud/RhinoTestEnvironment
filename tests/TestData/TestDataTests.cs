using System.Collections;

namespace Tests
{

	[RhinoFixture]
	public sealed class TestDataTests
	{

		[Theory]
		[TestCaseSource(nameof(TestPoints))]
		public void IsRealPoint(Point3d point)
		{
			Assert.That(point.X, Is.GreaterThanOrEqualTo(0));
			Assert.That(point.Y, Is.GreaterThanOrEqualTo(0));
			Assert.That(point.Z, Is.GreaterThanOrEqualTo(0));
		}

		public static IEnumerable TestPoints
		{
			get
			{
				for (int i = 0; i < 100; i++)
				{
					yield return new Point3d(i, i, i);
				}
			}
		}

	}

}
