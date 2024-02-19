using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;

/// <summary>Injects Rhino Assemblies into the AppDomain of tests</summary>
public class RhinoFixtureAttribute : TestFixtureAttribute
{

	/// <summary>Default Constructor</summary>
	public RhinoFixtureAttribute() : this(Array.Empty<object>())
	{
	}

	/// <summary>
	/// Construct with a object[] representing a set of arguments. The arguments may
	/// later be separated into type arguments and constructor arguments.
	/// </summary>
	/// <param name="arguments"></param>
	public RhinoFixtureAttribute(params object?[]? arguments) : base(arguments)
	{
		Init(null);
	}

	/// <summary>Initialises the Rhino Environment</summary>
	/// <param name="options"></param>
	protected static void Init(FixtureOptions? options)
	{
		if (NUnitTestFixture.Instance is null)
		{
			options ??= FixtureOptions.Default;

			NUnitTestFixture.Instance = new();
			NUnitTestFixture.Instance.Init(options);
		}
	}
}