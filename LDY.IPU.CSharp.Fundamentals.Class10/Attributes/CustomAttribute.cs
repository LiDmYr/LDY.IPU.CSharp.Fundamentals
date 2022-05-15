using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDY.IPU.CSharp.Fundamentals.Class10.Attributes {
    // Декорируется атрибутом
    // именованый и позиционный параметры

    //[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    // new AttributeUsage(AttributeTargets.All) { AllowMultiple = true }
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class CustomAttribute : Attribute {
        public string DeclaredAt { get; set; }

        public DateTime DeclaredAt_Advanced { get; set; } = DateTime.Now;

        public string DeclaredBy { get; set; }

        public CustomAttribute(string declaredBy) {
            DeclaredBy = declaredBy;
        }

        public void ExecuteAttributeMagic() {
            Console.WriteLine("===> CustomAttribute.ExecuteAttributeMagic()");
        }
    }
}
