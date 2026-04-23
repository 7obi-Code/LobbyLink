using System;
using System.Collections.Generic;
using System.Text;

namespace LobbyLink.DataAccess.Model
{
    public class ItemProperty
    {
        public int ItemPropertyId { get; set; }
        public string ItemPropertyName { get; set; }
        public string FilterType { get; set; }
        public bool IsFilterable { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public List<ItemPropertyValue> ItemPropertyValues { get; set; }
        public ItemProperty() { }
    }
}
