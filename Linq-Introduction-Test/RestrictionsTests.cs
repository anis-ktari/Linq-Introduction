using Linq_Introduction;
using NUnit.Framework;

namespace Linq_Introduction_Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [TestCase(5, 1)]
        public void Should_return_list_if_numbers_lower_than_minimum(int value, int resultCount)
        {
            // Arrange
            var restrictions = new Restrictions();
            var numbers = restrictions.Numbers;

            // Act
            var result = restrictions.ReturnSubListWhereValuesAreLowerThan(numbers, value);

            // Assert
            Assert.True(result.Length == resultCount);
        }
    }
}