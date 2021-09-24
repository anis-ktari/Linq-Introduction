using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Linq_Introduction
{
    public class Projections
    {
        public static int[] Numbers = { 7, 12, 13, 14, 15, 18, 16, 17, 20, 0 };

        public static int[] NumbersPlusTwo = { 9, 14, 15, 16, 17, 20, 18, 19, 22, 2};


        public static int[] ReturnsPlusTwo(int[] numbers)
        {
            var query =
                from number in numbers
                select number + 2;
            return query.ToArray();
        }
    }
}
