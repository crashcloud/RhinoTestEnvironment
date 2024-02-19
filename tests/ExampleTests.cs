using Grasshopper.Kernel.Types;

namespace RhinoTestEnvironment.Tests
{

	[RhinoFixture]
	public sealed class ExampleTests
	{

		[TestCase]
		public void Brep_Translation()
		{

			// Arrange
			var bb = new BoundingBox(new Point3d(0, 0, 0), new Point3d(100, 100, 100));
			var brep = bb.ToBrep();
			var t = Transform.Translation(new Vector3d(30, 40, 50));

			// Act
			brep.Transform(t);

			// Assert
			Assert.That(brep.GetBoundingBox(true).Center, Is.EqualTo(new Point3d(80, 90, 100)));

		}

		/// <summary>
		/// Xunit Test to Intersect sphere with a plane to generate a circle
		/// </summary>
		[TestCase]
		public void Brep_Intersection()
		{
			// Arrange
			var radius = 4.0;
			var brep = Brep.CreateFromSphere(new Sphere(new Point3d(), radius));
			var cuttingPlane = Plane.WorldXY;

			// Act
			Rhino.Geometry.Intersect.Intersection.BrepPlane(brep, cuttingPlane, 0.001, out var curves, out var points);

			// Assert
			// Assert.Single(curves);
			Assert.That(2 * Math.PI * radius, Is.EqualTo(curves[0].GetLength()));
		}

		/// <summary>
		/// Xunit Test to ensure Centroid of GH_Box outputs a GH_Point
		/// </summary>
		[TestCase]
		public void GHBox_Centroid_ReturnsGHPoint()
		{
			// Arrange
			var myBox = new GH_Box(new Box());

			// Act 
			var result = myBox.Boundingbox.Center;

			// Assert
			Assert.That(result is Point3d, Is.True);
		}

	}
}
