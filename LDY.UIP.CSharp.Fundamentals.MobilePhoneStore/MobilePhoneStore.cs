using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test {
    public class MobilePhoneStore {
        public string Address { get; private set; }

        public MobilePhone[] Phones { get; } 

        public MobilePhoneStore(string address, int storeCapacity) {
            this.Address = address;
            this.Phones = new MobilePhone[storeCapacity];
        }

        public bool AddPhoneToStore(MobilePhone phone) {
            for (int i = 0; i < Phones.Length; i++) {
                if (Phones[i] == null) {
                    Phones[i] = phone;
                    return true;
                }
            }
            return false;
        }

        internal string GetDescription() {
            return $"with address '{this.Address}' and capacity '{this.Phones.Length}'";
        }
    }
}
