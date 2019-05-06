using LDY.IPU.CSharp.Fundamentals.Class6.OOP_Inheritance.HW;
using System;
using System.Collections.Generic;

namespace LDY.IPU.CSharp.Fundamentals.Class6.OOP_Inheritance {
    public class Program {
        private static void Main(string[] args) {
            // 1) Inheritance
            var dog0 = new Dog() { Age = 1, Weight = 10, Name = "Dog-Clark" };
            var duck0 = new WildDuck() { Age = 4, Weight = 2, CountryWhereGoInWinter = "Zanzibzar" };
            var cat0 = new Cat() { Age = 3, Weight = 4, Name = "Cat-Clark" };
            
            if (false) {
                Console.WriteLine(dog0);

                string dogaaa = dog0.ToString();
                string dog1aa = dog0.GetType().FullName;
                string a = 10.ToString();

                List<Animal> animals_example = new List<Animal>();
                animals_example.Add(dog0);
                animals_example.Add(duck0);
                animals_example.Add(cat0); 
            }

            // 2) UpCasting vs DownCasting
            if (false) {
                List<Animal> animals = new List<Animal>();
                //{
                //    dog0,
                //    duck0,
                //    cat0
                //};
                animals.Add((Animal)dog0);
                animals.Add(duck0);
                animals.Add((Animal)cat0);

                // UP
                Animal animal1 = (Animal)dog0;
                Console.WriteLine(animal1);
                Animal animal2 = duck0;
                Animal animal3 = cat0;

                HomeAnimal homeAnimal1 = dog0;
                WildAnimal wildanimal2 = duck0;
                HomeAnimal homeAnimal3 = cat0;

                // DOWN
                // Dog castedDog = homeAnimal1; // MISTAKE
                // Cat castedCat = homeAnimal2; // MISTAKE
                // Duck castedDuck = homeAnimal3; // MISTAKE

                Dog castedDogFromAnimal = (Dog)animal1;
                WildDuck castedDuckFromAnimal = (WildDuck)animal2;
                Cat castedCatFromAnimal = (Cat)animal3;

                Dog castedDogFromHomeAnimal = (Dog)homeAnimal1;
                WildDuck castedDuckFromWildAnimal = (WildDuck)wildanimal2;
                Cat castedCatFromHomeAnimal = (Cat)homeAnimal3;

                Cat castedDuckAttemp = (Cat) animal2; // MISTAKE

                // Способы преобразований(Downcasting):
                // 1 ключевое слово as:
                // Dog castedAnimalAS = animal1 as Dog;
                Dog castedAnimalAS = animal2 as Dog; // MISTAKE
                if (castedAnimalAS != null) {
                    castedAnimalAS.ProtectAHuman();
                    castedAnimalAS.MakeSound();
                }
                // 2 отлавливаниe исключения InvalidCastException:
                try {
                    Dog castedAnimalTRYCATCH = (Dog)animal1;
                    // Dog castedAnimalTRYCATCH = (Dog)animal2; // MISTAKE
                    castedAnimalTRYCATCH.ProtectAHuman();
                    castedAnimalTRYCATCH.MakeSound();
                } catch (InvalidCastException ex) {
                    Console.WriteLine(ex.Message);
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                }
                // ключевого слова is:
                if (animal2 is Dog castedAnimalIS) {  // MISTAKE
                // if (animal1 is Dog) {
                    // Dog castedAnimalIS = (Dog)animal2;
                    castedAnimalIS.ProtectAHuman();
                    castedAnimalIS.MakeSound();
                }
            }

            // 3) Virtual + Override
            if (false) {
                var dog1 = new Dog() { Age = 1, Weight = 10, Name = "Dog-Clark-1" };
                var duck1 = new WildDuck() { Age = 4, Weight = 2, CountryWhereGoInWinter = "Zanzibzar" };
                var cat1 = new Cat() { Age = 3, Weight = 4, Name = "Cat-Clark-1" };
                var dog2 = new Dog() { Age = 1, Weight = 10, Name = "Dog-Clark-2" };
                var duck2 = new WildDuck() { Age = 4, Weight = 2, CountryWhereGoInWinter = "Tailand" };
                var cat2 = new Cat() { Age = 3, Weight = 4, Name = "Cat-Clark-2" };

                Console.WriteLine(" Virtual + Override");
                var animals = new List<Animal>() 
                {
                    cat1,
                    cat2,
                    dog1,
                    dog2,
                    duck1,
                    duck2
                };
                foreach (var animal in animals) {
                    animal.MakeSound();
                }
            }

            // Task - create classes hierarchy
            //HomoSapiens
            //Father
            //Mother
            //Person
            //Unemployed
            //Employee
            //Plumber

            // Task with Weapon
        }
    }
    #region Inheritance + override + UpCasting vs DownCasting
    internal class Animal {
        public int Age { get; set; }
        public int Weight { get; set; }

        public Animal() {
            Console.WriteLine("public Animal()");
        }

        public virtual void MakeSound() {
            Console.WriteLine("Animal Makes Sound");
        }
    }

    internal class WildAnimal : Animal {
        public string CountryWhereGoInWinter { get; set; }

        public WildAnimal() {
            Console.WriteLine("public WildAnimal()");
        }
    }

    internal class HomeAnimal : Animal {
        public string Name { get; set; }

        public HomeAnimal() : base() {
            Console.WriteLine("public HomeAnimal()");
        }
    }

    internal class WildDuck : WildAnimal {
        public WildDuck() {
            Console.WriteLine("public Duck()");
        }

        public void fly() {
            Console.WriteLine("I cant't believe I'm flying");
        }

        public override void MakeSound() {
            Console.WriteLine("Kra-Kra");
        }
    }

    internal class Cat : HomeAnimal {
        public Cat() {
            Console.WriteLine("public Cat()");
        }

        public void MakeCatEyes() {
            Console.WriteLine("Look at my eyes, give me a food");
        }

        public override void MakeSound() {
            Console.WriteLine("Myau-Myau");
        }
    }

    internal class Dog : HomeAnimal {
        public Dog() : base() {
            Console.WriteLine("public Dog()");
        }

        public void ProtectAHuman() {
            Console.WriteLine("Don't touch my Human");
        }

        public override void MakeSound() {
            Console.WriteLine("Gav-Gav");
        }
    }
    #endregion
}
