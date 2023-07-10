using Rhino.Commands;
using Rhino.DocObjects;

namespace RhinoTestEnvironment.Tests.Commands
{

	public sealed class SelCommandTests
	{

		internal sealed class SelTestCommand : SelCommand
		{
			public override string EnglishName => nameof(SelTestCommand);

			protected override bool SelFilter(RhinoObject rhObj)
			{
				return rhObj is not null;
			}
		}


		[Test]
		public void ExampleTest()
		{
			// Arrange
			SelTestCommand comm = new();

			// Assert
			Assert.That(comm.EnglishName, Is.Not.Empty);
			Assert.That(comm.PlugIn, Is.Not.Null);
			Assert.That(comm.LocalName, Is.Not.Empty);
			Assert.That(comm.Id, Is.Not.EqualTo(Guid.Empty));
			Assert.That(comm.Settings, Is.Not.Null);
		}

	}

}
