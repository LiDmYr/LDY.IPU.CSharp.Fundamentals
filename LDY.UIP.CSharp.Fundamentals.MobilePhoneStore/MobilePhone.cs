using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test {
    public class MobilePhone {
        public string Model { get; private set; }

        public int Price { get; private set; }

        public MobilePhone(string model, int price) {
            this.Model = model;
            this.Price = price;
        }

        internal string GetDescription() {
            return $"model name '{this.Model}' and price '{this.Price}'";
        }
    }
}
