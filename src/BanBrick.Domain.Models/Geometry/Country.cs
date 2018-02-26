using System;
using System.Collections.Generic;
using System.Text;

namespace BanBirck.Domain.Models.Geometry
{
    public class Country : ICloneable, IComparable<Country>, IEquatable<Country>
    {
        public Country() {
            Code = string.Empty;
            Name = string.Empty;
        }

        public Country(string code, string name) : this()
        {
            Code = code;
            Name = name;
        }

        public string Code { get; set; }

        public string Name { get; set; }

        public object Clone()
        {
            return new Country(Code, Name);
        }

        public int CompareTo(Country other)
        {
            return Name.CompareTo(other.Name);
        }

        public bool Equals(Country other)
        {
            return Code == other.Code && Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            return Equals((Country)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = -918270878;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Code);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
        
        public static bool operator ==(Country a, Country b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Country a, Country b)
        {
            return !a.Equals(b);
        }
    }
}
