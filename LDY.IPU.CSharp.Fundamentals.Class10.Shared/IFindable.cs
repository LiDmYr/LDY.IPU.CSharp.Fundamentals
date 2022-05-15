using System;
using System.Collections.Generic;
using System.Text;

namespace LDY.IPU.CSharp.Fundamentals.Class10.Shared {
    public interface IFindable {
        string Name { get; }

        int Number { get; }

        void SaySomething();
    }
}
