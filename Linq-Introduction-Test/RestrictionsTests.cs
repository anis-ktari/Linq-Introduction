using System.Collections;
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

        [TestCase(97, 2)]
        [TestCase(100, 1)]
        [TestCase(300, 0)]
        [TestCase(1, 72)]
        public void Should_return_expensive_and_instock_products(decimal expensivePrice, int expectedResult)
        {
            // Arrange
            var restrictions = new Restrictions();
            var products = Products.ProductList;

            // Act
            List<Product> result = restrictions.ReturnsExpensiveInStockProducts(products, expensivePrice);

            // Assert
            Assert.AreEqual(expectedResult, result.Count);
        }


        [TestCaseSource(nameof(DifferentProductLists))]
        public void Should_return_expensive_and_instock_products_with_different_datasources(IEnumerable<Product> productsDataSource, decimal expensivePrice, int expectedResult)
        {
            // Arrange
            var restrictions = new Restrictions();

            // Act
            var result = restrictions.ReturnsExpensiveInStockProducts(productsDataSource.ToList(), expensivePrice);

            // Assert
            Assert.AreEqual(expectedResult, result.Count);
        }

        private static IEnumerable DifferentProductLists
        {
            get
            {
                yield return new TestCaseData(Products.ProductList, 97M, 2);
                yield return new TestCaseData(Products.ProductList, 300M, 0);
                yield return new TestCaseData(Products.ProductList, 1M, 72);
                
                yield return new TestCaseData(Products.SmallProductList, 21M, 1);
                yield return new TestCaseData(Products.SmallProductList, 23M, 0);
            }
        }

        [TestCaseSource(nameof(ProductNamesByCategory))]
        public void Should_return_list_productNames_when_provided_a_category(
            IEnumerable<Product> productsDataSource, string category, string expectedResult)
        {
            // Arrange
            var restrictions = new Restrictions();

            // Act
            string result = restrictions.ReturnsListProductNamesByCategory(productsDataSource.ToList(), category);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        private static IEnumerable ProductNamesByCategory
        {
            get
            {
                yield return new TestCaseData(Products.SmallProductList, "Beverages", "Chai,Chang");
                yield return new TestCaseData(Products.SmallProductList, "Condiments", "Aniseed Syrup,Chef Anton's Cajun Seasoning,Chef Anton's Gumbo Mix");
            }
        }
    }
}