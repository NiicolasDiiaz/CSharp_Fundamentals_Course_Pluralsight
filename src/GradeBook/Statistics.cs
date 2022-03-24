namespace GradeBook
{
    public class Statistics
    {
        public double Low;
        public double High;
        public char Letter;
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public double Sum { get; private set; }
        public int Count{ get; private set; }

        public Statistics()
        {
            this.Count = 0;
            this.Average = 0.0;
            this.Sum = 0.0;
            this.High = double.MinValue;
            this.Low = double.MaxValue;
        }

        public void Add(double newValue)
        {
            this.Sum += newValue;
            this.Count++;

            this.Low = Math.Min(grade, result.Low);
            this.High = Math.Max(grade, result.High);
        }
    }
}
