using System;
using System.Collections.Generic;
using System.Text;

namespace BanBirck.Domain.Models.Geometry
{
    public class State : ICloneable, IComparable<State>, IEquatable<State>
    {
        public State() {
            Name = string.Empty;
            Code = string.Empty;
            Abbreviation = string.Empty;
        }

        public State(string name, string code) : this()
        {
            Name = name;
            Code = code;
        }

        public State(string name, string code, string abbreviation) : this(name, code)
        {
            Abbreviation = abbreviation;
        }

        public State(string name, string code, string abbreviation, Country country)
            : this(name, code, abbreviation)
        {
            Country = country;
        }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Abbreviation { get; set; }

        public Country Country { get; set; }

        public object Clone()
        {
            return new State(Name, Code, Abbreviation, Country);
        }
        
        public int CompareTo(State other)
        {
            return Name.CompareTo(other.Name);
        }

        public bool Equals(State other)
        {
            return Name == other.Name && Code == other.Code && Abbreviation == other.Abbreviation && Country == other.Country;
        }

        public override bool Equals(object obj)
        {
            return Equals((State)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = 1087569092;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Code);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Abbreviation);
            hashCode = hashCode * -1521134295 + EqualityComparer<Country>.Default.GetHashCode(Country);
            return hashCode;
        }

        public static bool operator ==(State a, State b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(State a, State b)
        {
            return !a.Equals(b);
        }
    }
}
