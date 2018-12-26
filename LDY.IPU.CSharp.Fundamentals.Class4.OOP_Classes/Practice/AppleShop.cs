using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class4.OOP_Classes.Practice {
    public class AppleShop {
        private AppleStorage[] AppleStorages;

        public AppleShop() {
            this.AppleStorages = new AppleStorage[] {
                new AppleStorage("Polevaya,3" , 10),
                new AppleStorage("Saksganskiok, 10" , 2)
            };
        }

        internal void StartWorking() {
            this.SupplyProducts("Polevaya, 3", 5, "Apple");
        }

        private void SupplyProducts(string AddressOfStorage, int countProducts, string FruitName) {
            AppleStorage currentStorage = this.GetStorageByAddress(AddressOfStorage);
            currentStorage.AddProducts(5, "Apple");
            
        }

        private AppleStorage GetStorageByAddress(string addressOfStorage) {
            return this.AppleStorages[0];
        }
    }

    internal class AppleStorage {
        public string Address { get; }

        public int Capacity { get; }

        public Fruit[] Fruits { get; }

        public AppleStorage(string Address, int capacity) {
            this.Address = Address;
            this.Capacity = capacity;
            this.Fruits = new Fruit[this.Capacity];
        }

        internal void AddProducts(int countFruits, string FruitName) {
            for (int i = 0; i < countFruits; i++) {
                this.Fruits[i] = new Fruit(FruitName);
            }
        }
    }

    internal class Fruit {
        public string Name { get; }

        public Fruit(string Name) {
            this.Name = Name;
        }
    }
}
