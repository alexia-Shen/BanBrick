using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Infrastructure.Scrapy.Models
{
    public class ScrapySourceType : ICloneable, IEquatable<ScrapySourceType>
    {
        public ScrapySourceType() { }

        public ScrapySourceType(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public bool Equals(ScrapySourceType other)
        {
            return Name == other.Name;
        }

        public object Clone()
        {
            return new ScrapySourceType(Name);
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return Name;
        }

        public static bool operator ==(ScrapySourceType a, ScrapySourceType b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(ScrapySourceType a, ScrapySourceType b)
        {
            return !a.Equals(b);
        }

        public static ScrapySourceType Html => new ScrapySourceType("Html");

        public static ScrapySourceType Json => new ScrapySourceType("Json");

        public static ScrapySourceType Constant => new ScrapySourceType("Constant");

        public static ScrapySourceType Header => new ScrapySourceType("Header");
    }
}
