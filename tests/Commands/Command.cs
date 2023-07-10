using Rhino;
using Rhino.Commands;

namespace RhinoTestEnvironment.Tests.Commands
{

	public sealed class CommandTests
	{

		private sealed class TestCommand : Command
		{
			public override string EnglishName => nameof(TestCommand);

			protected override Result RunCommand(RhinoDoc doc, RunMode mode)
			{
				return Result.Nothing;
			}
		}

		[Test]
		public void ExampleTest()
		{
			// Arrange
			Command comm = new TestCommand();

			// Assert
			Assert.That(comm.EnglishName, Is.Not.Empty);
			Assert.That(comm.PlugIn, Is.Not.Null);
			Assert.That(comm.LocalName, Is.Not.Empty);
			Assert.That(comm.Id, Is.Not.EqualTo(Guid.Empty));
			Assert.That(comm.Settings, Is.Not.Null);
		}

	}

}
