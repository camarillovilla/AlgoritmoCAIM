using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmoCAIM
{    
    public class Interval
    {
        public List<double> discretizationScheme = new List<double>();
        public double caim;
        public int[,] matrix;
        public int numberOfClasses = 3;

        public Interval(List<double> discretizationScheme, int[,] matrix)
        {
            foreach(double value in discretizationScheme)
            {
                this.discretizationScheme.Add(value);
            }

            this.matrix = matrix;
            CalculateCAIM();
        }

        public void CalculateCAIM()
        {
            double sum = 0;

            for (int i = 0; i < numberOfClasses; i++)
            {
                // IntervalTotal: sum of the columns of the matrix
                sum += ((Math.Pow(GetHigher(i), 2)) / IntervalTotal(i));
            }

            this.caim = (sum / (discretizationScheme.Count - 1));
        }

        public int GetHigher(int value)
        {
            int max = this.matrix[value, 0];

            for (int i = 1; i < (discretizationScheme.Count - 1); i++)
            {
                if (max < this.matrix[value, i])
                {
                    max = this.matrix[value, i];
                }
            }

            return max;
        }

        // Sum of the columns of the matrix.
        public int IntervalTotal(int value)
        {
            int sum = 0;

            for (int i = 0; i < (discretizationScheme.Count - 1); i++)
            {
                sum += this.matrix[value, i];
            }

            return sum;
        }
    }
}
