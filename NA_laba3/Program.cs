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
            //double[,] A1 = new double[n, n] { { 2, 0.2, -1, 0 }, { 0.4, -8.5, 0.5, 4 }, { 0.3, -1, 5.2, 1 }, { 1, 0.2, -1, 2.5 } };
            //double[] d = new double[n] { 2.7, 21.9, -3.9, 9.9 };

            double[,] A1 = new double[n, n] { { -0.86, 0.23, 0.18, 0.17 }, { 0.12, -1.14, 0.08, 0.09 }, { 0.16, 0.24, -1, -0.35 }, { 0.23, -0.08, 0.05, -0.75 } };
            double[] d = new double[n] { 1.42, 0.83, -1.21, -0.65 };

            int c = 1;
            double[] x = d;
            double[] newX = MethodZeidel(A1, d, n, x);
            double newE = MAX(x, newX);
            Console.Write(0+" ");
            for (int i = 0; i < n; i++) Console.Write(newX[i] + "\t");
            Console.WriteLine(newE);
            while (10E-10 < newE)
            {
                x = newX;
                newX = MethodZeidel(A1, d, n, newX);
                Console.Write(c+" ");
                for (int i = 0; i < n; i++) Console.Write(newX[i] + "\t");
                newE = MAX(x, newX);
                Console.Write(newE+"\n");
                c++;
            }

            Console.WriteLine("inccuracy = " + Matrix.Error(d, Matrix.MulMatrix(A1, newX, n, n), n));

            Console.ReadLine();
        }
        
        private static double MAX(double[] x, double[] n_x)
        {
            double max = Math.Abs(x[0] - n_x[0]);
            for (int i = 1; i < x.Length; i++) if (Math.Abs(x[i] - n_x[i]) > max) max = Math.Abs(x[i] - n_x[i]);
            return max;
        }
        private static double[] MethodZeidel(double[,] A, double[] B, int n, double[] x_k)
        {
            double[] newX = new double[n];
            for(int i = 0; i < n; i++)
            {
                newX[i] = B[i] / A[i, i];
                for (int j = 0; j < i; j++)
                {
                    newX[i] -= (A[i, j] / A[i, i]) * newX[j];
                }
                for (int j = i + 1; j < n; j++)
                {
                    newX[i] -= (A[i, j] / A[i, i]) * x_k[j];
                }
            }
            return newX;
        }
        private static double[] recur(double[,] A,double[] B, int n, double[] x_k, int k)
        {
            if (k == 0) return MethodZeidel(A, B, n, x_k);

            return MethodZeidel(A, B, n, x_k);
        }

        #region Диагональное преобладание
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
        public static double[,] GetDiagonalDominance(double[,] A, int n)
        {

            return A;
        }
        #endregion

        #region Определитель
        public static double GetDeterminant_3(double[,] A, int n)
        {
            return A[0, 0] * A[1, 1] * A[2, 2] + A[0, 1] * A[1, 2] * A[2, 0] + A[1, 0] * A[2, 1] * A[0, 2] - A[2, 0] * A[1, 1] * A[0, 2] - A[1, 0] * A[0, 1] * A[2, 2] - A[2, 1] * A[1, 2] * A[0, 0];
        }
        public static double[,] GetMinor(double[,] A, int n, int i, int j)
        {
            double[,] M = new double[n - 1, n - 1];

            for (int k = 0; k < n; k++)
            {
                for (int m = 0; m < n; m++)
                {
                    //if (i != k && m != j)
                    //{
                    if (k < i && m < j) M[k, m] = A[k, m];
                    if (k > i && m > j) M[k - 1, m - 1] = A[k, m];
                    if (k > i && m < j) M[k - 1, m] = A[k, m];
                    if (k < i && m > j) M[k, m - 1] = A[k, m];
                    //}
                }
            }

            return M;
        }
        public static double GetDeterminant_4(double[,] A, int n)
        {
            double determ = 0;
            for (int i = 0; i < n; i++)
            {
                determ += A[0, i] * Math.Pow(-1, 2 + i) * GetDeterminant_3(GetMinor(A, n, 0, i), n);
            }
            return determ;
        }
        #endregion

        #region
        #endregion

    }
}
