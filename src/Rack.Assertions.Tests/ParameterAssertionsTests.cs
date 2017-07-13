using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnitAssert = NUnit.Framework.Assert;

namespace Rack.Assertions.Tests
{
    [TestFixture]
    public class ParameterAssertionsTests
    {
        [Test]
        public void IsShouldThrowWhenAssertionIsNotMet()
        {
            Assert.Parameter.Is(true, "Assertion failed!", "parameterName");

            NUnitAssert.Throws<ArgumentException>(
                () => Assert.Parameter.Is(false, "Assertion failed!", "parameterName")
            );
        }

        [Test]
        public void IsNotNullShouldThrowWhenParameterIsNull()
        {
            var nonNullObject = new object();
            Assert.Parameter.IsNotNull(nonNullObject, "parameterName");

            NUnitAssert.Throws<ArgumentNullException>(
                () => Assert.Parameter.IsNotNull(null, "parameterName")
            );
        }

        [Test]
        public void IsNotNullOrEmptyShouldThrowWhenParameterIsNullOrEmpty()
        {
            Assert.Parameter.IsNotNullOrEmpty("Not null or empty string", "parameterName");

            NUnitAssert.Throws<ArgumentNullException>(
                () => Assert.Parameter.IsNotNullOrEmpty(null, "parameterName")
            );

            NUnitAssert.Throws<ArgumentException>(
                () => Assert.Parameter.IsNotNullOrEmpty(string.Empty, "parameterName")
            );
        }

        [Test]
        public void IsGreaterThanShouldThrowWhenNotGreaterThan()
        {
            Assert.Parameter.IsGreaterThan(9, 1, "parameterName");

            NUnitAssert.Throws<ArgumentOutOfRangeException>(
                () => Assert.Parameter.IsGreaterThan(1, 1, "parameterName")
            );

            NUnitAssert.Throws<ArgumentOutOfRangeException>(
                () => Assert.Parameter.IsGreaterThan(1, 9, "parameterName")
            );
        }

        [Test]
        public void IsGreaterThanOrEqualToShouldThrowWhenNotGreaterThanOrEqualTo()
        {
            Assert.Parameter.IsGreaterThanOrEqualTo(9, 1, "parameterName");
            Assert.Parameter.IsGreaterThanOrEqualTo(1, 1, "parameterName");

            NUnitAssert.Throws<ArgumentOutOfRangeException>(
                () => Assert.Parameter.IsGreaterThanOrEqualTo(1, 9, "parameterName")
            );
        }


        [Test]
        public void IsLessThanShouldThrowWhenNotLessThan()
        {
            Assert.Parameter.IsLessThan(1, 9, "parameterName");

            NUnitAssert.Throws<ArgumentOutOfRangeException>(
                () => Assert.Parameter.IsLessThan(1, 1, "parameterName")
            );

            NUnitAssert.Throws<ArgumentOutOfRangeException>(
                () => Assert.Parameter.IsLessThan(9, 1, "parameterName")
            );
        }

        [Test]
        public void IsLessThanOrEqualToShouldThrowWhenNotLessThanOrEqualTo()
        {
            Assert.Parameter.IsLessThanOrEqualTo(1, 9, "parameterName");
            Assert.Parameter.IsLessThanOrEqualTo(1, 1, "parameterName");

            NUnitAssert.Throws<ArgumentOutOfRangeException>(
                () => Assert.Parameter.IsLessThanOrEqualTo(9, 1, "parameterName")
            );
        }

        [Test]
        public void IsWithinRangeShouldThrowWhenNotWithinRange()
        {
            Assert.Parameter.IsWithinRange(5, 0, 10, "parameterName");
            Assert.Parameter.IsWithinRange(5, 5, 10, "parameterName");
            Assert.Parameter.IsWithinRange(5, 0, 5, "parameterName");

            NUnitAssert.Throws<ArgumentOutOfRangeException>(
                () => Assert.Parameter.IsWithinRange(10, 0, 5, "parameterName")
            );
        }

        [Test]
        public void IsIndexInRangeShouldThrowWhenOutOfRange()
        {
            Assert.Parameter.IsIndexInRage(0, 10, "parameterName");
            Assert.Parameter.IsIndexInRage(5, 10, "parameterName");

            NUnitAssert.Throws<ArgumentOutOfRangeException>(
                () => Assert.Parameter.IsIndexInRage(-1, 10, "parameterName")
            );

            NUnitAssert.Throws<ArgumentOutOfRangeException>(
                () => Assert.Parameter.IsIndexInRage(10, 10, "parameterName")
            );

            NUnitAssert.Throws<ArgumentOutOfRangeException>(
                () => Assert.Parameter.IsIndexInRage(11, 10, "parameterName")
            );
        }
    }
}
