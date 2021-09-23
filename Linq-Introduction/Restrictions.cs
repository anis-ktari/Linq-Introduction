using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Linq_Introduction
{
    public class Restrictions
    {
        public int[] Numbers = { 7, 12, 13, 14, 15, 18, 16, 17, 20, 0 };

        public int[] ReturnSubListWhereValuesAreLowerThan(int[] numbers, int value)
        {
            var query = 
                from number in Numbers 
                where number < value select number;

            return query.ToArray();
        }
    }
}
