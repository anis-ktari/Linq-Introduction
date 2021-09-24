using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        [Test]
        public void Should_return_Number_In_Englsih()
        {
            // Arrange
            var expectedResult = Projections.NumbersToEnglish;

            // Act
            string[] result = Projections.ReturnsToEnglish(Projections.SimpleNumbers);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        [Test]
        public void Should_return_Collection_Of_Uppercase_And_Lowercase()
        {
            // Arrange
            var expectedResult = new List<string> { "APPLE", "BLUEBERRY", "CHERRY" };

            // Act
            string[] result = Projections.ReturnsUppercaseAndLowercase(Projections.words);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        [Test]
        public void Should_return_Collection_Of_Tuples()
        {
            // Arrange
            IEnumerable<(string Upper, string Lower)> expectedResult = new List<(string Upper, string Lower)>
            {
                ("APPLE","apple"),
                ("BLUEBERRY","blueberry"),
                ("CHERRY","cherry"),
            };

            // Act
            IEnumerable<(string Upper, string Lower)> result = Projections.ReturnsCollectionOfTuples(Projections.words);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
        //[Test]
        //public void Should_return_Collection_Of_Complex_words()
        //{
        //    // Arrange
        //    var expectedResult = new[]
        //    {
        //        new
        //        {
        //            Number = 7,
        //            English = "seven",
        //            EvenOrOdd = "odd"
        //        },
        //        new
        //        {
        //            Number = 0,
        //            English = "zero",
        //            EvenOrOdd = "even"
        //        },
        //        new
        //        {
        //            Number = 5,
        //            English = "five",
        //            EvenOrOdd = "odd"
        //        },

        //        new
        //        {
        //            Number = 3,
        //            English = "three",
        //            EvenOrOdd = "odd"
        //        },
        //};

        //    // Act
        //    var results = Projections.ReturnsCollectionOfComplexWords(Projections.SimpleNumbers);

        //    // Assert

        //    //from result in results
        //    //    from expected in expectedResult
        //    //select results.

        //Assert.AreEqual(expectedResult.ToList(), results);
        //}


        [Test]
        public void Should_return_Collection_Of_Complex_words_class()
        {
            // Arrange
            var expectedResult = new List<ComplexWord>
            {
                new ComplexWord (7,"seven","odd"),
                new ComplexWord (0,"zero","even"),
                new ComplexWord (5,"five","odd"),
                new ComplexWord (3,"three","odd"),
            };

            // Act
            IEnumerable<ComplexWord> results = Projections.ReturnsCollectionOfComplexWordsClass(Projections.SimpleNumbers);

            // Assert
            Assert.AreEqual(expectedResult, results.ToList());
        }

    }
}