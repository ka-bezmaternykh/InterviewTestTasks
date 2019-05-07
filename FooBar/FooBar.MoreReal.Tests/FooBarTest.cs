using System;
using System.Collections.Generic;
using System.Linq;
using FooBar.MoreReal.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FooBar.MoreReal.Tests
{
    [TestClass]
    public class FooBarTest
    {
        [TestMethod]
        [DataRow(1, 100)]
        [DataRow(25, 100)]
        public void RangeConfigAndCountOfMessagesEquals(int from, int to)
        {
            // Arrange
            // +1 is index shift
            var shouldBeCount = (to - from) + 1;
            var config = new Config
            {
                Range = new Range(from, to)
            };
            var fooBar = new FooBar(config);

            // Act
            var messages = fooBar.FooBars();

            // Assert
            Assert.AreEqual(shouldBeCount, messages.Count());
        }

        [TestMethod]
        public void RuleProducesMessageInCorrectCases()
        {
            // Arrange
            var expected = new string[7] { "1", "2", "Foo", "4", "5", "Foo", "7" };
            var config = new Config
            {
                Range = new Range(1, 7)
            }.AddRule(new Rule
            {
                SerialIndex = 3,
                Message = "Foo"
            });
            var fooBar = new FooBar(config);

            // Act
            var messages = fooBar.FooBars();

            // Assert
            CollectionAssert.AreEqual(expected, messages.ToArray());
            
        }

        [TestMethod]
        public void IfRulesIntersectsMessagesIsConcatenating()
        {
            // Arrange
            var expected = new string[] { "1", "2", "Foo", "4", "Bar", "Foo", "7", "8", "Foo", "Bar", "11", "Foo", "13", "14", "FooBar", "16" };
            var config = new Config
            {
                Range = new Range(1, 16)
            }.AddRule(new Rule
            {
                SerialIndex = 3,
                Message = "Foo"
            }).AddRule(new Rule
            {
                SerialIndex = 5,
                Message = "Bar"
            });
            var fooBar = new FooBar(config);

            // Act
            var messages = fooBar.FooBars();

            // Assert
            CollectionAssert.AreEqual(expected, messages.ToArray());
        }
    }
}
