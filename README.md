![Logo](art\Logo.png)
# Rhino Test Environment

Allows for creating Unit Tests that run inside of the Rhino domain. See [Tests folder](tests/). for some examples.

## How to use it

RhinoCommonUnitTesting is an open source library and NuGet package that aims to simplify the process of unit testing RhinoCommon-based projects. It provides a set of utility classes and methods that facilitate the creation and execution of unit tests for RhinoCommon-based functionality.

## Installation

RhinoCommonUnitTesting can be easily installed via the NuGet Package Manager Console or the Visual Studio Package Manager. Run the following command to install the package:

```pwsh
nuget install RhinoCommonUnitTesting
```

## Getting Started

To quickly get started with RhinoCommonUnitTesting, create a single class as outlined below, or shown in the [Tests folder](tests/).

``` c#
using NUnit.Framework;

[SetUpFixture]
public sealed class TestSetup
{

	[OneTimeSetUp]
	public void Setup()
	{
		NUnitTestFixture fixture = new NUnitTestFixture();
		fixture.Init(new FixtureOptions());
	}

}
```

## Contributing
Contributions are welcome and encouraged! If you'd like to contribute to RhinoCommonUnitTesting, please review the [Contributing Guidelines](docs/CONTRIBUTING.md) for instructions on how to get started.

## Examples

The [Tests folder](tests/) contains a set of example projects that showcase various use cases and best practices for unit testing RhinoCommon-based projects. These examples can serve as a reference point for understanding how to structure your tests and make the most out of RhinoCommonUnitTesting.

## License

RhinoCommonUnitTesting is released under the [MIT License](LICENSE.md).

## Acknowledgments

[Forked From](https://github.com/tmakin/RhinoCommonUnitTesting)
