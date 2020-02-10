using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class Matrix
    {
        private double[,] matrix;

        private Matrix() { }

        public Matrix(int dimension)
        {
            if (dimension < 1)
            {
                throw new ArgumentException();
            }
            this.matrix = new double[dimension, dimension];
        }

        public int GetDimension()
        {
            return this.matrix.GetLength(0);
        }

        public void SetAt(int row, int column, double value)
        {
            if (row < 0 || row > this.matrix.GetLength(0) || column < 0 ||
                column > this.matrix.GetLength(0))
            {
                throw new ArgumentException();
            }
            this.matrix[row, column] = value;
        }

        public double GetAt(int row, int column)
        {
            if (row < 0 || row > this.matrix.GetLength(0) || column < 0 ||
                column > this.matrix.GetLength(0))
            {
                throw new ArgumentException();
            }
            return this.matrix[row, column];
        }

        public static Matrix Addition(Matrix m1, Matrix m2, double factor = 1)
        {
            if (m1 == null || m2 == null ||
                m1.GetDimension() != m2.GetDimension())
            {
                throw new ArgumentException();
            }
            Matrix result = new Matrix(m1.GetDimension());
            for (int i = 0; i < m1.GetDimension(); i++)
            {
                for (int j = 0; j < m1.GetDimension(); j++)
                {
                    result.SetAt(i, j, m1.GetAt(i, j) + factor * m2.GetAt(i, j));
                }
            }
            return result;
        }

        public static Matrix Subtraction(Matrix m1, Matrix m2)
        {
            return Matrix.Addition(m1, m2, -1);
        }

        public static Matrix Multiplication(Matrix m1, Matrix m2,
                                            double factor = 1)
        {
            if (m1 == null || m2 == null ||
                m1.GetDimension() != m2.GetDimension())
            {
                throw new ArgumentException();
            }
            Matrix result = new Matrix(m1.GetDimension());
            for (int i = 0; i < m1.GetDimension(); i++)
            {
                for (int j = 0; j < m1.GetDimension(); j++)
                {
                    for (int k = 0; k < m1.GetDimension(); k++)
                    {
                        result.SetAt(i, j, result.GetAt(i, j) + factor *
                                           m1.GetAt(i, k) * m2.GetAt(k, j));

                    }
                }
            }
            return result;
        }

        public static Matrix InitializeMatrix()
        {
            int dimension;
            do
            {
                try
                {
                    Console.Write("Insert dimension: ");
                    dimension = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Only numbers, try again...");
                    dimension = 0;
                }
            } while (dimension <= 0);
            Matrix result = new Matrix(dimension);
            bool valid;
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    valid = false;
                    do
                    {
                        try
                        {
                            Console.Write($"Value at ({i}, {j}): ");
                            result.SetAt(i, j,
                                         Convert.ToDouble(Console.ReadLine()));
                            valid = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Only numbers, try again...");
                        }
                    } while (!valid);
                }
            }
            return result;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(0); j++)
                {
                    builder.Append($"{Convert.ToString(matrix[i, j])} ");
                }
                builder.Append("\n");
            }
            return builder.ToString();
        }
    }
}
