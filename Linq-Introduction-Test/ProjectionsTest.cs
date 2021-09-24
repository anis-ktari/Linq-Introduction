using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Linq_Introduction;
using Linq_Introduction.DataSources;
using NUnit.Framework;

namespace Linq_Introduction_Test
{
    public class ProjectionsTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_return_Plus_two_list ()
        {
            // Arrange
            var expectedResult = Projections.NumbersPlusTwo;

            // Act
            int[] result = Projections.ReturnsPlusTwo(Projections.Numbers);
            
            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}