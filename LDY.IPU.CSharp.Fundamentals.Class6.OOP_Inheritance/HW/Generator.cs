namespace LDY.IPU.CSharp.Fundamentals.Class6.OOP_Inheritance.HW {
    public class Generator : ElectricDevice {
        public override int AvailablePower => GeneratedPower;

        public int GeneratedPower { get; }

        public Generator(int producedPower) {
            GeneratedPower = producedPower;
        }

        public override string ToString() {
            return $"generator Id#{base.ToString()}";
        }
    }
}
