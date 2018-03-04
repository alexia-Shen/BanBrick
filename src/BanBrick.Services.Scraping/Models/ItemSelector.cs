using BanBrick.Services.Scraping.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BanBrick.Services.Scraping.Models
{
    public class ItemSelector
    {
        public ItemSelector()
        {
            PropertySelectors = new List<PropertySelector>();
        }

        public string Selector { get; set; }
        
        public SelectorType SelectorType { get; set; } 

        public IList<PropertySelector> PropertySelectors { get; set; }
    }
}
