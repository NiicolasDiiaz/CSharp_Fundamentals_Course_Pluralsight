namespace GradeBook
{
    public class Statistics
    {
        public double Low;
        public double High;
        public char Letter
        {
            get
            {
                switch (this.Average)
                {
                    case var d when d >= 90.0:
                        return 'A';

                    case var d when d >= 80.0:
                        return 'B';

                    case var d when d >= 70.0:
                        return 'C';

                    case var d when d >= 60.0:
                        return 'D';

                    default:
                        return 'F';
                }
            }
        }
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }

        public double Sum { get; private set; }
        public int Count { get; private set; }

        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0.0;
            this.High = double.MinValue;
            this.Low = double.MaxValue;
        }

        public void Add(double newValue)
        {
            this.Sum += newValue;
            this.Count++;

            this.Low = Math.Min(newValue, this.Low);
            this.High = Math.Max(newValue, this.High);
        }
    }
}
