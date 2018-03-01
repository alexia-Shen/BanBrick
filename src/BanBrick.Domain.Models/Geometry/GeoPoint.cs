using System;
using System.Collections.Generic;
using System.Text;

namespace BanBirck.Domain.Models.Geometry
{
    public class GeoPoint : ICloneable, IEquatable<GeoPoint>
    {
        public GeoPoint() { }
        
        public GeoPoint(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public object Clone()
        {
            return new GeoPoint(Latitude, Longitude);
        }
        
        public bool Equals(GeoPoint other)
        {
            return Latitude == other.Latitude && Longitude == other.Longitude;
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return Equals((GeoPoint)obj);
        }

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + Latitude.GetHashCode();
            hashCode = hashCode * -1521134295 + Longitude.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(GeoPoint a, GeoPoint b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(GeoPoint a, GeoPoint b)
        {
            return !a.Equals(b);
        }
    }
}
