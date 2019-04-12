using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NA_laba3
{
    class Matrix
    {
        public static double determinant;
        public static int[] countX;
        public static int CountTransposition = 0;
        #region Гаусс
        public static double[,] gauss(double[,] A, int n)
        {
            determinant = 1;
            for (int i = 0; i < n; i++)
            {
                double buf = A[i, i];
                determinant *= buf;
                for (int j = i; j < n + 1; j++) A[i, j] /= buf;

                for (int k = i + 1; k < n; k++)
                {
                    buf = A[k, i];
                    for (int j = i; j < n + 1; j++)
                        A[k, j] = buf * A[i, j] - A[k, j];
                }
            }
            Output(A, n, n + 1);
            Console.WriteLine("Determinant = " + determinant);
            return A;
        } 
        /// <summary>
           /// Инициализация вектора индексов неизвестного Х
           /// </summary>
           /// <param name="cX"></param>
           /// <param name="n"></param>
           /// <returns></returns>
        public static int[] InitialX(int[] cX, int n)
        {
            int[] countX = new int[n];
            for (int i = 0; i < n; i++)
                countX[i] = i;
            return countX;
        }
        public static double[] obr(double[,] A, int n)
        {
            InitialX(countX, n);
            double[] x = new double[n + 1];
            // int c = n-1;
            for (int i = n - 1; i >= 0; i--)
            {
                double buf = 0;
                for (int k = i; k < n; k++)
                {
                    //if(i!=0)
                    buf += A[i, k] * x[k];
                }
                x[i] = A[i, n] - buf;
                Console.Write(string.Format("X{0} = {1:F2}\n", i, x[i]));
                //c--;
            }
            return x;
        }
        #endregion
        /// <summary>
        /// Вывод матрицы
        /// </summary>
        /// <param name="A"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        public static void Output(double[,] A, int n, int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(string.Format("{0:F2} ", A[i, j]));
                Console.WriteLine();
            }
            Console.WriteLine("----------------------------------------------------------");
        }
        /// <summary>
        /// Вывод вектора
        /// </summary>
        /// <param name="A"></param>
        /// <param name="n"></param>
        public static void Output(double[] A, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Format("{0:F2} ", A[i]));
            }
            Console.WriteLine("----------------------------------------------------------");
        }
        /// <summary>
        /// умножение матриц
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="k"></param>
        public static double[,] MulMatrix(double[,] A, double[,] B, int n, int m, int k)
        {
            double[,] C = new double[n, k];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    for (int c = 0; c < m; c++)
                    {
                        C[i, j] += A[i, c] * B[c, j];
                    }
                }
            }
            //Output(C, n, k);
            return C;
        }
        /// <summary>
        /// Умножение матрицы на вектор
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="k"></param>
        public static double[] MulMatrix(double[,] A, double[] B, int n, int m)
        {
            double[] C = new double[n];
            for (int i = 0; i < n; i++)
            {
                for (int c = 0; c < m; c++)
                {
                    C[i] += A[i, c] * B[c];
                }
            }
          //  Output(C, n);
            return C;
        }/// <summary>
         /// Ошибка матриц
         /// </summary>
         /// <param name="A"></param>
         /// <param name="n"></param>
         /// <param name="b"></param>
        public static double Error(double[,] A, double[,] A_1, int n)
        {
            double[,] sub = new double[n, n];
            for (int i = 0; i < n; i++) for (int j = 0; j < n; j++) sub[i, j] = Math.Abs(A[i, j] - A_1[i, j]);
            double myB = average(A, n);
            double b = average(sub, n);
            return b / myB;
            Console.WriteLine("inccuracy = " + b / myB);
            Console.WriteLine("------------------------------------------------------------------");
        }
        /// <summary>
        /// Ошибка вектора
        /// </summary>
        /// <param name="B"></param>
        /// <param name="B_1"></param>
        /// <param name="n"></param>
        public static double Error(double[] B, double[] B_1, int n)
        {
            double[] sub = new double[n];
            for (int i = 0; i < n; i++) sub[i] = Math.Abs(B[i] - B_1[i]);
            double b = average(B, n);
            double new_b = average(sub, n);
            return new_b / b;
            Console.WriteLine("inccuracy = " + new_b / b);
        }
        /// <summary>
        /// Среднее квадратичное вектора
        /// </summary>
        /// <param name="B"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double average(double[] B, int n)
        {
            double delta = 0;
            for (int i = 0; i < n; i++)
                delta += B[i] * B[i];
            return delta = Math.Sqrt(delta);
        }
        /// <summary>
        /// Среднее квадратичное матрицы
        /// </summary>
        /// <param name="A"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double average(double[,] A, int n)
        {
            double delta = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    delta += A[i, j] * A[i, j];
            }

            delta = Math.Sqrt(delta);
            return delta;
        }
        /// <summary>
        /// Из квадратной матрицы А получаем прямоугольную путем добавления столбца В
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public static double[,] ExtendedMatrix(double[,] A, double[] B, int n)
        {
            double[,] newA = new double[n, n + 1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    if (j == n) newA[i, j] = B[i];
                    else newA[i, j] = A[i, j];
                }
            }
            return newA;
        }
        /// <summary>
        /// Получение столбца В из расширенной матрицы
        /// </summary>
        /// <param name="A"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static double[] GetBFromExtendedMatrix(double[,] A, int n, int m)
        {
            double[] B = new double[n];
            for (int i = 0; i < n; i++)
                B[i] = A[i, m - 1];
            return B;
        } /// <summary>
          /// 
          /// </summary>
          /// <param name="A"></param>
          /// <param name="n"></param>
          /// <param name="a">Индекс строки, которую нужно заменить на строку с индекс К</param>
          /// <param name="k">Индекс строки, которую нужно заменить на строку индекс А</param>
          /// <returns></returns>
        public static double[,] Colum(double[,] A, int n, int a, int k)
        {
            for (int i = 0; i < n + 1; i++)
            {
                double buf = A[a, i];
                A[a, i] = A[k, i];
                A[k, i] = buf;
            }
            return A;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="A"></param>
        /// <param name="n"></param>
        /// <param name="a">Индекс столбца</param>
        /// <param name="k">Индекс столбца</param>
        /// <returns></returns>
        public static double[,] Row(double[,] A, int n, int a, int k)
        {
            for (int i = 0; i < n; i++)
            {
                double buf = A[i, a];
                A[i, a] = A[i, k];
                A[i, k] = buf;
            }
            int c = countX[a];
            countX[a] = countX[k];
            countX[k] = c;
            return A;
        }
    }
}