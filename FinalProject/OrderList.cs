using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FinalProject
{
    [XmlRoot("OrderList")]
    [XmlInclude(typeof(Battery))]
    [XmlInclude(typeof(Tire))]
    [XmlInclude(typeof(WindShieldWiper))]
    public class OrderList : IEnumerable<Item>
    {
        private List<Item> itemList = null;

        [XmlArray("Items")]
        [XmlArrayItem("Item", typeof(Item))]
        public List<Item> ItemList
        {
            get { return this.itemList; }
            set { this.itemList = value; }
        }

        public OrderList()
        {
            itemList = new List<Item>();
        }

        public void Add(Item item)
        {
            itemList.Add(item);
        }

        public int Count
        {
            get { return itemList.Count; }
        }

        public Item this[int i]
        {
            get { return itemList[i]; }
            set { itemList[i] = value; }
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return ((IEnumerable<Item>)itemList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Item>)itemList).GetEnumerator();
        }
    }
}
