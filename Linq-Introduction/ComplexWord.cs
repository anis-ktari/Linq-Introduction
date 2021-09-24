using System;

namespace Linq_Introduction
{
    public class ComplexWord : IEquatable<ComplexWord>
    {
        public int Number { get; set; }
        public string English { get; set; }
        public string EvenOrOdd { get; set; }

        public ComplexWord(int number, string english, string evenOrOdd)
        {
            this.Number = number;
            English = english;
            EvenOrOdd = evenOrOdd;
        }

        public bool Equals(ComplexWord other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Number == other.Number && English == other.English && EvenOrOdd == other.EvenOrOdd;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComplexWord)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Number, English, EvenOrOdd);
        }
    }
}