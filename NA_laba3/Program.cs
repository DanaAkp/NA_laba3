using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA_laba3
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 4;
            double[,] A1 = new double[n, n] { { 2, 0.2, -1, 0 }, { 0.4, -8.5, 0.5, 4 }, { 0.3, -1, 5.2, 1 }, { 1, 0.2, -1, 2.5 } };
            double[] d = new double[n] { 2.7, 21.9, -3.9, 9.9 };

            //double[,] A1 = new double[n, n] { { -0.86, 0.23, 0.18, 0.17 }, { 0.12, -1.14, 0.08, 0.09 }, { 0.16, 0.24, -1, -0.35 }, { 0.23, -0.08, 0.05, -0.75 } };
            //double[] d = new double[n] { 1.42, 0.83, -1.21, -0.65 };

            double[,] A = Matrix.ExtendedMatrix(A1, d, n);


        }
        public static bool IsDiagonalDominance(double[,] A, int n)
        {
            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < n; j++) if (i != j) sum += A[i, j];
                if (sum > A[i, i]) return false;
            }
            return true;
        }

        public static double GetDeterminant_3(double[,] A, int n)
        {
            return A[0, 0] * A[1, 1] * A[2, 2] + A[0, 1] * A[1, 2] * A[2, 0] + A[1, 0] * A[2, 1] * A[0, 2] - A[2, 0] * A[1, 1] * A[0, 2] - A[1, 0] * A[0, 1] * A[2, 2] - A[2, 1] * A[1, 2] * A[0, 0];
        }
        public static double[,] GetMinor(double[,] A, int n, int i,int j)
        {
            double[,] M = new double[n - 1, n - 1];

            for (int k = 0; k < n; k++)
            {
                for (int m = 0; m < n; m++)
                {
                    if (i != k && m != j)
                    {
                        if (i < k) M[k, m] = A[k, m];
                    }
                }
            }

            return M;
        }
        public static double GetDeterminant_4(double[,] A, int n)
        {
            double determ = 1;
            for(int i = 0; i < n; i++)
            {

            }
            return determ;
        }
        public static double[,] GetDiagonalDominance(double[,] A,int n)
        {

            return A;
        }
    }
}
