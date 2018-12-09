using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class5.OOP_Classes.Factory {
    public class Order {
        public Item[] Items { get; private set; }
        public bool IsCompleted { get; private set; }
        public string Id { get; private set; }

        public Order(Item[] items, string id) {
            this.Items = items;
            this.Id = id;
        }

    }
}
