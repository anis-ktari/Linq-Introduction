using System.Collections.Generic;
using System.Linq;
using Linq_Introduction.DataSources;

namespace Linq_Introduction
{
    public class Restrictions
    {
        public int[] Numbers = { 7, 12, 13, 14, 15, 18, 16, 17, 20, 0 };

        public int[] ReturnSubListWhereValuesAreLowerThan(int[] numbers, int value)
        {
            var query = 
                from number in numbers
                where number < value select number;

            return query.ToArray();
        }


        public List<Product> ReturnsProductsOutOfStockDeclarative(List<Product> products)
        {
           var query =
               from product in products
               where product.UnitsInStock == 0
               select product;

           return query.ToList();
           //return products.Where(tt => tt.UnitsInStock == 0).ToList();
        }

        public List<Product> ReturnsProductsOutOfStockIterative(List<Product> products)
        {
           // Iterative
            var result = new List<Product>();

            foreach (var product in products)
            {
                if (product.UnitsInStock == 0)
                    result.Add(product);
            }

            return result;
        }
    }
}
