using System;
using System.Collections.Generic;
using System.Text;

namespace BanBirck.Domain.Models.Geometry
{
    public class Suburb : ICloneable, IComparable<Suburb>, IEquatable<Suburb>
    {
        public Suburb() {
            Name = string.Empty;
            Code = string.Empty;
        }

        public Suburb(string name, string code) : this()
        {
            Name = name;
            Code = code;
        }

        public Suburb(string name, string code, State state) : this(name, code)
        {
            State = state;
        }

        public string Name { get; set; }

        public string Code { get; set; }

        public State State { get; set; }

        public object Clone()
        {
            return new Suburb(Name, Code, State);
        }

        public int CompareTo(Suburb other)
        {
            return Name.CompareTo(other.Name);
        }

        public bool Equals(Suburb other)
        {
            return Name == other.Name && Code == other.Code && State == other.State;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            var hashCode = -29519056;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Code);
            hashCode = hashCode * -1521134295 + EqualityComparer<State>.Default.GetHashCode(State);
            return hashCode;
        }

        public static bool operator ==(Suburb a, Suburb b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Suburb a, Suburb b)
        {
            return !a.Equals(b);
        }
    }
}
