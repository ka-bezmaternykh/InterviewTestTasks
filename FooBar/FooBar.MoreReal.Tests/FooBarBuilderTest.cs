using System;
using FooBar.MoreReal.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FooBar.MoreReal.Tests
{
    [TestClass]
    public class FooBarBuilderTest
    {
        [TestMethod]
        public void BuildingFooBarWithNoSettingsThrowsException()
        {
            // Arrange
            var fooBarBuilder = new FooBarBuilder();

            // Act && Assert
            Assert.ThrowsException<InvalidOperationException>(() => fooBarBuilder.Build());
        }

        [TestMethod]
        public void BuildingFooBarWithDefaultsIsSuccesful()
        {
            // Arrange
            var fooBarBuilder = new FooBarBuilder()
                .UseDefaults();

            // Act
            var fooBar = fooBarBuilder.Build();

            // Assert
            Assert.IsNotNull(fooBar);
        }

        [TestMethod]
        [DataRow(100, 1)]
        [DataRow(0, 0)]
        [DataRow(-1, 100)]
        public void SettingInvalidRangeThrowsException(int from, int to)
        {
            // Arrange
            var fooBarBuilder = new FooBarBuilder()
                .UseDefaults();

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => fooBarBuilder.SetRange(from, to));
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(-0)]
        public void AddingRuleWithNonPositiveSerialIndexThrowsException(int serialIndex)
        {
            // Arrange
            var fooBarBuilder = new FooBarBuilder();

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => 
                fooBarBuilder.AddRule(serialIndex, "FooBar"));
        }

        [TestMethod]
        [DataRow(1000, 1, 100)]
        [DataRow(10, 25, 100)]
        public void BuildFooBarWithRuleOutOfRangeThrowsException(int serialIndex, int from, int to)
        {
            // Arrange
            var fooBarBuilder = new FooBarBuilder().SetRange(from, to)
                .AddRule(serialIndex, "FooBar");

            // Act && Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => fooBarBuilder.Build());
        }

        [TestMethod]
        public void BuildFooBarWithRuleInsideOfRangeIsSuccesful()
        {
            // Arrange
            var fooBarBuilder = new FooBarBuilder().SetRange(1, 100)
                .AddRule(3, "FooBar");

            // Act
            var fooBar = fooBarBuilder.Build();

            // Assert
            Assert.IsNotNull(fooBar);
        }
    }
}
