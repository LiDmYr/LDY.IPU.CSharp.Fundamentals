using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using LDY.IPU.CSharp.Fundamentals.Class4.OOP_Classes.Separatedfiles;

namespace LDY.IPU.CSharp.Fundamentals.Class4.OOP_Classes {
    public class Program {
        public static void Main(string[] args) {
            // 0 Reference type VS Value type
            if (false) {
                int[] array = new int[] { 1, 2, 3 };
                ModifyIntArray(array);

                int valueTypeInt = 10;
                ModifyInt(valueTypeInt); 
            }

            // 1) Class + Constructor
            if (false) {
                Person person = new Person();
                person.Age = 10;
                Person person1 = new Person();
                Person person2 = person;
                person2.Age = 20;
                Console.WriteLine(person.Age);

                int a = 10;
                int b = a;
                b = 20;
                Console.WriteLine(a);
            }

            // 2) Access modifiers
            if (false) {
                PersonAccessModifiers personAccessModifiers = new PersonAccessModifiers();
                personAccessModifiers.PublicMethod();
                personAccessModifiers.InternalMethod();
                //personAccessModifiers.ProtectedMethod();
                //personAccessModifiers.PrivateMethod();
            }

            // 3) Fields + Readonly
            if (false) {
                PersonFieldsReadonly personFieldsReadonly = new PersonFieldsReadonly();
                personFieldsReadonly.AgePublic = 10;
                int personFieldsReadonlyAgePublic = personFieldsReadonly.AgePublic;
                //personAccessModifiers.AgeProtected = 30;
                personFieldsReadonly.AgeInternal = 20;
                //personAccessModifiers.AgePrivate = 40; 
                //personFieldsReadonly.AgeReadonly = 10; 
            }

            // 4) Properties
            if (false) {
                PersonProperties personProperties = new PersonProperties();
                int currentAge = personProperties.EncapsulatedAge;
                personProperties.EncapsulatedAge = 50;
                personProperties.EncapsulatedAge = -1;
                personProperties.EncapsulatedAge = 100;
                int personPropertiesAgeProtectedProperty = personProperties.AgeProtectedProperty;
                // personProperties.AgeProtectedProperty = 10;
            }

            // 5) Constructors with parameters
            if (false) {
                PersonThisConstructors personThisConstructorsDefault =
                    new PersonThisConstructors();
                PersonThisConstructors personThisConstructorsName = 
                    new PersonThisConstructors("name");
                PersonThisConstructors personThisConstructorsNameAge = 
                    new PersonThisConstructors("name", 20);
            }

            Console.ReadLine();
        }
        #region 0 Reference type VS Value type
        private static void ModifyInt(int valueTypeInt) {
            valueTypeInt = 100000;
        }

        private static void ModifyIntArray(int[] array) {
            for (int i = 0; i <= array.Length - 1; i++) {
                array[i] = 0;
            }
        } 
        #endregion
    }

    #region 1) Class + Constructor
    internal class Person {
        internal int Age;

        internal void AssignAge() {
            this.Age = 10;
            Age = 1000;
        }
    }
    #endregion

    #region 2) Access modifiers
    class PersonAccessModifiers {
        public PersonAccessModifiers() {
            Console.WriteLine("PersonAccessModifiers");
            this.PrivateMethod();
        }

        public void PublicMethod() {
            Console.WriteLine("PublicMethod");
        }

        protected void ProtectedMethod() {
            Console.WriteLine("ProtectedMethod");
        }

        internal void InternalMethod() {
            Console.WriteLine("InternalMethod");
        }

        private void PrivateMethod() {
            Console.WriteLine("PrivateMethod");
        }
    }
    #endregion

    #region 3) Fields + Readonly
    class PersonFieldsReadonly {
        public int AgePublic;

        protected int AgeProtected;

        internal int AgeInternal;

        private int AgePrivate;

        internal readonly int AgeReadonly = 0;

        public PersonFieldsReadonly() {
            this.AgeReadonly = 10;
        }

    }
    #endregion

    #region 4) Properties
    class PersonProperties {
        public int AgePublicProperty { get; set; }

        public int AgePublicPropertyGet { get; }

        public int AgePublicField;

        public int AgeProtectedProperty { get; protected set; }

        public int AgeInternalProperty { get; internal set; }

        public int AgePrivateProperty { get; private set; }

        public int EncapsulatedAge {
            get {
                Console.WriteLine($"Value is gotten");
                return this._EncapsulatedAge;
            }
            set {
                if (value > 0 && value < 1000) {
                    this._EncapsulatedAge = value;
                    Console.WriteLine($"Value is set");
                } else {
                    Console.WriteLine($"{value} is not valid");
                }
            }
        }
        private int _EncapsulatedAge = -1; // don't assign this field directly from inside class

        public PersonProperties() {

        }
    }
    #endregion

    #region 5) Constructors with parameters
    public class PersonThisConstructors {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public PersonThisConstructors() : this("noname") {
        }

        public PersonThisConstructors(string name) : this(name, 0) {
        }

        public PersonThisConstructors(string name, int age) {
            this.Name = name;
            this.Age = age;
        }

        public void GetInfo() {
            Console.WriteLine($"Имя: {this.Name} Возраст: {this.Age}");
        }

    }
    #endregion
}



