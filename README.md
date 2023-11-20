![Logo](art/Logo.png)
# Rhino Test Environment

Allows for creating Unit Tests that run inside of the Rhino domain. See [Tests folder](tests/). for some examples.

## How to use it

RhinoTestFixture is an open source library and NuGet package that aims to simplify the process of unit testing RhinoCommon-based projects. It provides a set of utility classes and methods that facilitate the creation and execution of unit tests for RhinoCommon-based functionality.

## Installation

RhinoTestEnvironment can be easily installed via the NuGet Package Manager Console or the Visual Studio Package Manager. Run the following command to install the package:

```pwsh
nuget install RhinoTestEnvironment
```

## Getting Started

To quickly get started with RhinoTestEnvironment, use the default attribute `[RhinoFixture]` above all of your test classes as shown in the [Tests folder](tests/).
``` c#
[RhinoFixture]
public class MyTestClass
{
    [Test]
    public void MyTest()
    {
        // ...
```


If you wish to override the default options, you can always create your own!
``` c#
public class MyCustomTestFixtureAttribute : RhinoFixtureAttribute
{
	public MyCustomTestFixtureAttribute()
	{
		var options = new FixtureOptions
		{
			Version = RhinoVersion.v8,
		};
		Init(options);
	}
}
```

## Contributing
Contributions are welcome and encouraged! If you'd like to contribute to RhinoTestEnvironment, please review the [Contributing Guidelines](docs/CONTRIBUTING.md) for instructions on how to get started.

## Examples

The [Tests folder](tests/) contains a set of example projects that showcase various use cases and best practices for unit testing RhinoCommon-based projects. These examples can serve as a reference point for understanding how to structure your tests and make the most out of RhinoTestEnvironment.

## License

RhinoCommonUnitTesting is released under the [MIT License](LICENSE.md).

## Acknowledgments

[Forked From](https://github.com/tmakin/RhinoCommonUnitTesting)
