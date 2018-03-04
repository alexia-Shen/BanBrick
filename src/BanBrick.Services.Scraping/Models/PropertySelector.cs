using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Services.Scraping.Models
{
    public class PropertySelector
    {
        public string Selector { get; set; }

        public string Name { get; set; }

        public string Regex { get; set; }
    }
}
