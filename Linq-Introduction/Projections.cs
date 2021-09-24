using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Linq_Introduction
{
    //public class CompexWordComparer : IEqualityComparer<ComplexWord>
    //{
    //    public bool Equals(ComplexWord x, ComplexWord y)
    //    {
    //        if (ReferenceEquals(x, y)) return true;
    //        if (ReferenceEquals(x, null)) return false;
    //        if (ReferenceEquals(y, null)) return false;
    //        if (x.GetType() != y.GetType()) return false;
    //        return x.Number == y.Number && x.English == y.English && x.EvenOrOdd == y.EvenOrOdd;
    //    }

    //    public new bool Equals(object x, object y)
    //    {
    //            if (ReferenceEquals(null, y)) return false;
    //            if (ReferenceEquals(x, null)) return false;
    //            if (ReferenceEquals(x, y)) return true;
    //            if (x.GetType() != y.GetType()) return false;
    //            return Equals((ComplexWord)x,(ComplexWord)y);
    //    }

    //    public int GetHashCode(ComplexWord obj)
    //    {
    //        return HashCode.Combine(obj.Number, obj.English, obj.EvenOrOdd);
    //    }
    //}

    public class Projections
    {
        public static int[] Numbers = { 7, 12, 13, 14, 15, 18, 16, 17, 20, 0 };

        public static int[] NumbersPlusTwo = { 9, 14, 15, 16, 17, 20, 18, 19, 22, 2};

        public static int[] SimpleNumbers = { 7, 0, 5, 3 };
        
        public static string[] NumbersToEnglish = { "seven", "zero", "five", "three" };

        private static string[] englishWordsList = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" ,"ten", "eleven"};

        public static string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };


        public IEnumerable<ComplexWord> ReturnBiggerThanSimpleNumbers()
        {
            return from first in Numbers
                from second in SimpleNumbers
                where first <= second
                select new ComplexWord(first, englishWordsList[first], (first % 2 == 0) ? "even" : "odd");
        }



        public static int[] ReturnsPlusTwo(int[] numbers)
        {
            return (from number in numbers select number + 2).ToArray();
            //return numbers.Select(number => number + 2).ToArray();
        }

        public static string[] ReturnsToEnglish(int[] numbers)
        {
            return (from x in numbers select englishWordsList[x]).ToArray();
            //return numbers.Select(x => englishWordsList[x]).ToArray();
        }


        public static string[] ReturnsUppercaseAndLowercase(string[] words)
        {
            var complexList = (from word in words
                select new
                {
                    Original = word,
                    Upper = word.ToUpper(),
                    Lower = word.ToLower(),
                });

            return complexList.Select(x => x.Upper).ToArray();
        }

        public static IEnumerable<(string Upper, string Lower)> ReturnsCollectionOfTuples(string[] words)
        {
            var result = (from word in words select (word.ToUpper(), word.ToLower()));
            return result;
        }

        public static IEnumerable ReturnsCollectionOfComplexWords(int[] numbers)
        {
            var complexWords = (from number in numbers
                select new
                {
                    Number = number,
                    English = englishWordsList[number],
                    EvenOrOdd = (number % 2 == 0)? "even":"odd"
                });
            return complexWords;
        }

        public static IEnumerable<ComplexWord> ReturnsCollectionOfComplexWordsClass(int[] numbers)
        {
            //var complexWords =
            //    (from number in numbers
            //     select new ComplexWord(number, englishWordsList[number], (number % 2 == 0) ? "even" : "odd"));
            //return complexWords;

            var complexAnonymes = ReturnsCollectionOfComplexWords(numbers);

            return complexAnonymes.Cast<ComplexWord>().ToList();
        }

        private static int[] _numbersA = { 7, 12, 13, 14, 15, 18, 16, 17, 20, 0 };

        private static int[] _numbersB = { 9, 14, 15, 16, 17 };

        public static IEnumerable<(int lowerInt, int GreaterInt)> ReturnsCollectionOfTuples(int[] firstList,int[] secondList)
        {
            var result = (
                from a in firstList 
                from b in secondList
                where a < b
                select (a, b));
            return result;
        }






    }
}
