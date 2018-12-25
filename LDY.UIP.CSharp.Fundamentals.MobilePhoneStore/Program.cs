using LDY.IPU.CSharp.Fundamentals.Class4.OOP_Classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test {
    class Program {
        static void Main(string[] args) {
            string[] commands = new string[] {
                "quit",
                "add store to shop",
                "add phone to store",
                "show all phones in stores",
                "clear console"
            };
            MobilePhoneShop iphoneShop = CreateMobileShopFromInput();
            string command = string.Empty; // OR string command = ""; OR string command = null;
            do {
                command = GetCommandFromInput(commands);
                ExecuteCommand(command, iphoneShop);
            } while (command != "quit");
            Console.ReadLine();
        }

        private static MobilePhoneShop CreateMobileShopFromInput() {
            string shopName;
            do {
                Console.WriteLine("Please write valid (not empty) name for shop");
                shopName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(shopName));

            Console.WriteLine($"=> Great, the name of shop is '{shopName}'");
            return new MobilePhoneShop(shopName);
        }

        private static string GetCommandFromInput(string[] commands) {
            string resultCommand = null;
            do {
                Console.WriteLine("------- NEW COMMAND ------");
                Console.WriteLine($"Please write index of command from list below. Commands:");
                PrintCommands(commands);

                bool isInputInt = int.TryParse(Console.ReadLine(), out int commandIndexFromInput);
                bool isValidInputInt = 
                    isInputInt && 
                    commandIndexFromInput >= 0 && 
                    commandIndexFromInput < commands.Length;

                if (isValidInputInt) {
                    resultCommand = commands[commandIndexFromInput];
                } else {
                    Console.WriteLine($"=> Invalid number");
                }
            } while (string.IsNullOrWhiteSpace(resultCommand));

            return resultCommand;
        }

        private static void PrintCommands(string[] commands) {
            int currentIndex = 0;
            foreach (var command in commands) {
                Console.WriteLine($" [{currentIndex}] = {command}");
                currentIndex++;
            }
        }

        private static void ExecuteCommand(string command, MobilePhoneShop iphoneShop) {
            switch (command) {
                case "quit": {
                        Console.WriteLine("=> Thank you. Good bye");
                        break;
                    }
                case "add store to shop": {
                        AddStoreToShop(iphoneShop);
                        break;
                    }
                case "add phone to store": {
                        AddPhoneToStore(iphoneShop);
                        break;
                    }
                case "show all phones in stores": {
                        PrintStores(iphoneShop, true, true);
                        break;
                    }
                case "clear console": {
                        Console.Clear();
                        break;
                    }
                default: {
                        Console.WriteLine("=> Wrong command");
                        break;
                    }
            }
        }

        private static void PrintStores(MobilePhoneShop iphoneShop,
                                        bool isShowPhonesInsideStore,
                                        bool isShowEmptyStores) {
            int currentMobilePhoneStoreIndex = 0;
            if (iphoneShop.MobilePhoneStores.Length == 0) {
                Console.WriteLine("=> Please Create some stores - iphoneShop.MobilePhoneStores.Length == 0");
            } else {
                Console.WriteLine($"=> Store in '{iphoneShop.GetDescription()}'");
                foreach (var mobilePhoneStore in iphoneShop.MobilePhoneStores) {
                    bool isMobilePhoneStoreEmpty = mobilePhoneStore == null;
                    if (!isShowEmptyStores && isMobilePhoneStoreEmpty) { continue; }
                    string stringToShow = $"[{currentMobilePhoneStoreIndex}] - Store cell is ";
                    stringToShow += isMobilePhoneStoreEmpty ? "empty" : $"'{mobilePhoneStore.GetDescription()}'";
                    Console.WriteLine(stringToShow);
                    if (isShowPhonesInsideStore && !isMobilePhoneStoreEmpty) {
                        PrintAllPhonesInStore(mobilePhoneStore);
                    }
                    currentMobilePhoneStoreIndex++;
                }
            }
        }

        private static void PrintAllPhonesInStore(MobilePhoneStore mobilePhoneStore) {
            int currentPhoneIndex = 0;
            foreach (var phone in mobilePhoneStore.Phones) {
                string stringToShow = $"   [{currentPhoneIndex}] - Phone cell is ";
                stringToShow += phone == null ? "empty" : $"'{phone.GetDescription()}'";
                Console.WriteLine(stringToShow);
                currentPhoneIndex++;
            }
        }

        private static void AddStoreToShop(MobilePhoneShop iphoneShop) {
            MobilePhoneStore mobilePhoneStore = CreateMobilePhoneStoreFromInput();
            iphoneShop.AddStore(mobilePhoneStore);
            Console.WriteLine($"=> Shop '{mobilePhoneStore.GetDescription()}' successfully created.");
        }

        private static MobilePhoneStore CreateMobilePhoneStoreFromInput() {
            string shopAddress = null;
            int shopCapacity = 0;
            do {
                Console.WriteLine("Please write shop address (text with length > 10) of store");
                shopAddress = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(shopAddress) || shopAddress.Length <= 10);
            do {
                Console.WriteLine("Please write capacity (number > 0 && number <= 10) of phones which could be in store");
                int.TryParse(Console.ReadLine(), out shopCapacity);
            } while (shopCapacity <= 0 || shopCapacity > 10);
            return new MobilePhoneStore(shopAddress, shopCapacity);
        }

        private static void AddPhoneToStore(MobilePhoneShop iphoneShop) {
            if (!IsAnyMobilePhoneStoreAvailable(iphoneShop)) {
                Console.WriteLine($"=> in {iphoneShop.GetDescription()} no real stores are available. Please add any real store before add a phone.");
                return;
            }
            MobilePhoneStore store = GetMobilePhoneStoreFromInput(iphoneShop);
            MobilePhone mobilePhone = CreatePhoneFromInput();
            bool isPhoneAddedToStore = iphoneShop.AddPhoneToStore(mobilePhone, store.Address);
            string resultMessage = isPhoneAddedToStore ? "successfully added" : "was not added";
            Console.WriteLine($"=> Phone with {mobilePhone.GetDescription()} {resultMessage} to store '{store.GetDescription()}'.");
        }

        private static bool IsAnyMobilePhoneStoreAvailable(MobilePhoneShop iphoneShop) {
            foreach (var mobilePhoneStores in iphoneShop.MobilePhoneStores) {
                if (mobilePhoneStores != null) {
                    return true;
                }
            }
            return false;
        }

        private static MobilePhone CreatePhoneFromInput() {
            string phoneModel = null;
            int phonePrice = 0;
            do {
                Console.WriteLine("Please write phone model name (text with length > 10)");
                phoneModel = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(phoneModel) || phoneModel.Length <= 10);
            do {
                Console.WriteLine("Please write price (number > 0 && number <= 100000) for phone");
                int.TryParse(Console.ReadLine(), out phonePrice);
            } while (phonePrice <= 0 || phonePrice > 100000);
            return new MobilePhone(phoneModel, phonePrice);
        }

        private static MobilePhoneStore GetMobilePhoneStoreFromInput(MobilePhoneShop mobilePhoneShop) {
            MobilePhoneStore[] mobilePhoneStores = mobilePhoneShop.MobilePhoneStores;
            MobilePhoneStore mobilePhoneStore = null;
            do {
                Console.WriteLine($"Please write index number of mobilePhoneStore from list below. MobilePhoneStores:");
                PrintStores(mobilePhoneShop, false , false);

                bool isInputInt = int.TryParse(Console.ReadLine(), out int mobilePhoneStoreIndexFromInput);
                bool isValidInputInt = 
                    isInputInt && 
                    mobilePhoneStoreIndexFromInput >= 0 && 
                    mobilePhoneStoreIndexFromInput < mobilePhoneStores.Length &&
                    mobilePhoneStores[mobilePhoneStoreIndexFromInput] != null;

                if (isValidInputInt) {
                    mobilePhoneStore = mobilePhoneStores[mobilePhoneStoreIndexFromInput];
                } else {
                    Console.WriteLine($"=> Invalid number");
                }
            } while (mobilePhoneStore == null);
            return mobilePhoneStore;
        }
    }
}
