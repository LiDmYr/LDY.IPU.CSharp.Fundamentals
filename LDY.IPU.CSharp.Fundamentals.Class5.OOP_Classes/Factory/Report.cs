namespace LDY.IPU.CSharp.Fundamentals.Class5.OOP_Classes.Factory {
    internal class Report {
        public bool ISuccess { get; set; }
        public string Message { get; set; }
        private string v;

        public Report(string v) {
            this.v = v;
        }
    }
}