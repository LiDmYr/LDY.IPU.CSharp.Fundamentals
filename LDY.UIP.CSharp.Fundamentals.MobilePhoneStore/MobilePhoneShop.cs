using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test {
    public class MobilePhoneShop {
        public string Name { get; set; }

        public MobilePhoneStore[] MobilePhoneStores {
            get {
                if (this._IPhoneStores == null) {
                    this._IPhoneStores = new MobilePhoneStore[5];
                }
                return this._IPhoneStores;
            }
        }
        private MobilePhoneStore[] _IPhoneStores = null;

        public MobilePhoneShop(string name) {

            this.Name = name;
        }

        internal void AddStore(MobilePhoneStore iPhoneStore) {
            for (int i = 0; i < MobilePhoneStores.Length; i++) {
                if (MobilePhoneStores[i] == null) {
                    MobilePhoneStores[i] = iPhoneStore;
                    break;
                }
            }
        }

        internal bool AddPhoneToStore(MobilePhone phone, string address) {
            foreach (var phoneStore in MobilePhoneStores) {
                if (phoneStore == null) {
                    continue;
                }

                if (phoneStore.Address == address) {
                    return phoneStore.AddPhoneToStore(phone);
                }
            }
            return false;
        }

        internal string GetDescription() {
            return $"'{this.Name}'";
        }
    }
}
