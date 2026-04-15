using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Model
{
    public class ItemProperty
    {
        public string PropertyTitle { get; set; }

        public string PropertyLabel { get; set; }

        public string FilterType { get; set; }

        public bool IsFilterable { get; set; }

        public List<ItemPropertyLine> ItemPropertyLines { get; set; }

        public List<ItemPropertyValue> ItemPropertyValues { get; set; }

        public ItemProperty(string propertyTitle, string propertyLabel, string filterType, bool isFilterable, List<ItemPropertyLine> itemPropertyLines, List<ItemPropertyValue> itemPropertyValues)
        {
            PropertyTitle = propertyTitle;
            PropertyLabel = propertyLabel;
            FilterType = filterType;
            IsFilterable = isFilterable;
            ItemPropertyLines = itemPropertyLines;
            ItemPropertyValues = itemPropertyValues;
        }
    }
}
