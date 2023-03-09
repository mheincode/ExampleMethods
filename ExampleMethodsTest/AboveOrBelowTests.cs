using ExampleMethods;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ExampleMethodsTest
{
    [TestClass]
    public class AboveOrBelowTests
    {
        [TestMethod]
        public void CountAboveOrBelow_ShouldReturnCorrectCounts_WhenListContainsOnlyOneElementLessThanComparisonValue()
        {
            var list = new List<int> { 3 };
            var comparisonValue = 6;

            var result = AboveOrBelow.CountAboveOrBelow(list, comparisonValue);

            result.Should().HaveCount(2);
            result["above"].Should().Be(0);
            result["below"].Should().Be(1);
        }

        [TestMethod]
        public void CountAboveOrBelow_ShouldReturnCorrectCounts_WhenListContainsOnlyOneElementGreaterThanComparisonValue()
        {

            var list = new List<int> { 9 };
            var comparisonValue = 4;

            var result = AboveOrBelow.CountAboveOrBelow(list, comparisonValue);

            result.Should().HaveCount(2);
            result["above"].Should().Be(1);
            result["below"].Should().Be(0);
        }

        [TestMethod]
        public void CountAboveOrBelow_ShouldReturnCorrectCounts_WhenListContainsMultipleElementsAboveAndBelowComparisonValue()
        {
            var list = new List<int> { 1, 3, 2, 1, 13 };
            var comparisonValue = 6;

            var result = AboveOrBelow.CountAboveOrBelow(list, comparisonValue);

            result.Should().HaveCount(2);
            result["above"].Should().Be(1);
            result["below"].Should().Be(4);
        }

        [TestMethod]
        public void CountAboveOrBelow_ShouldReturnZeroCounts_WhenListContainsOnlyElementsEqualToComparisonValue()
        {

            var list = new List<int> { 22, 22, 22, 22 };
            var comparisonValue = 22;

            var result = AboveOrBelow.CountAboveOrBelow(list, comparisonValue);

            result.Should().HaveCount(2);
            result["above"].Should().Be(0);
            result["below"].Should().Be(0);
        }

        [TestMethod]
        public void CountAboveOrBelow_ShouldReturnZeroCounts_WhenListIsEmpty()
        {
            var list = new List<int>();
            var comparisonValue = 6;

            var result = AboveOrBelow.CountAboveOrBelow(list, comparisonValue);

            result.Should().HaveCount(2);
            result["above"].Should().Be(0);
            result["below"].Should().Be(0);
        }
    }
}
