﻿using NUnit.Framework;
using NUnit.Framework.Internal;
using System;

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