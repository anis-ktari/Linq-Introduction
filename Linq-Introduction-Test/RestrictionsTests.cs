using System.Collections.Generic;
using System.Linq;
using Linq_Introduction;
using Linq_Introduction.DataSources;
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

        [TestCase(5)]
        public void Should_return_number_products_out_of_stock(int expectedResult)
        {
            // Arrange
            var restrictions = new Restrictions();
            var products = Products.ProductList;

            // Act
            List<Product> result = restrictions.ReturnsProductsOutOfStockDeclarative(products);

            // Assert
            Assert.AreEqual(expectedResult,result.Count);
        }

        [TestCase(1)]
        public void Should_return_expensive_and_instock_products(int expectedResult)
        {
            // Arrange
            var expensivePrice = 97M;
            var restrictions = new Restrictions();
            var products = Products.ProductList;

            // Act
            List<Product> result = restrictions.ReturnsExpensiveInStockProducts(products, expensivePrice);

            // Assert
            Assert.AreEqual(expectedResult, result.Count);
        }


    }
}