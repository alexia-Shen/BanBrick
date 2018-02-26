using System;
using System.Collections.Generic;
using System.Text;

namespace BanBirck.Domain.Models.Geometry
{
    public class Coordinate : ICloneable, IEquatable<Coordinate>
    {
        public Coordinate() { }

        public Coordinate(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }
        public double Y { get; set; }

        public object Clone()
        {
            return new Coordinate(X, Y);
        }
        
        public bool Equals(Coordinate other)
        {
            return X == other.X && Y == other.Y;
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return Equals((Coordinate)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Coordinate a, Coordinate b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Coordinate a, Coordinate b)
        {
            return !a.Equals(b);
        }
    }
}
