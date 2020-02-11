using System;
using System.Collections.Generic;
using System.Text;

namespace Homework3
{
    class Matrix
    {
        // 2D double array, private
        private double[,] matrix;

        // No 'empty' matrix
        private Matrix() { }

        // Constructor, dimension greater than 0, integer, initialized all 0
        public Matrix(int dimension)
        {
            // Less than zero dimension, fail...
            if (dimension < 1)
            {
                throw new ArgumentException();
            }
            this.matrix = new double[dimension, dimension];
        }

        // Dimension of 'first' layer
        public int GetDimension()
        {
            // this matrix.Length returns dimension^2
            return this.matrix.GetLength(0);
        }

        // Set value in specified row and column
        public void SetAt(int row, int column, double value)
        {
            // If index is out of bounds, fail...
            if (row < 0 || row > this.matrix.GetLength(0) || column < 0 ||
                column > this.matrix.GetLength(0))
            {
                throw new ArgumentException();
            }
            // Assign value
            this.matrix[row, column] = value;
        }

        // Get value at specified rown and column
        public double GetAt(int row, int column)
        {
            // If index is out of bounds, fail...
            if (row < 0 || row > this.matrix.GetLength(0) || column < 0 ||
                column > this.matrix.GetLength(0))
            {
                throw new ArgumentException();
            }
            // return value
            return this.matrix[row, column];
        }

        // Add 2 matrixes, with an optional factor (default 1) on the second
        public static Matrix Addition(Matrix m1, Matrix m2, double factor = 1)
        {
            // If not same dimensions or one (or both) of them are null, fail..
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
                    // New matrix, assign value
                    result.SetAt(i, j, m1.GetAt(i, j) + factor * m2.GetAt(i, j));
                }
            }
            return result;
        }

        // Same as addition, but factor is -1 on second matrix
        public static Matrix Subtraction(Matrix m1, Matrix m2)
        {
            return Matrix.Addition(m1, m2, -1);
        }

        // Multiplication
        public static Matrix Multiplication(Matrix m1, Matrix m2,
                                            double factor = 1)
        {
            if (m1 == null || m2 == null ||
                m1.GetDimension() != m2.GetDimension())
            {
                throw new ArgumentException();
            }
            // New matrix
            Matrix result = new Matrix(m1.GetDimension());
            // Row of matrix 1 with column of matrix 2
            for (int i = 0; i < m1.GetDimension(); i++)
            {
                for (int j = 0; j < m1.GetDimension(); j++)
                {
                    for (int k = 0; k < m1.GetDimension(); k++)
                    {
                        // Multiply entries, then add each result
                        result.SetAt(i, j, result.GetAt(i, j) + factor *
                                           m1.GetAt(i, k) * m2.GetAt(k, j));

                    }
                }
            }
            return result;
        }

        // Static Method, create matrix and assing values 1 by 1, validated
        public static Matrix InitializeMatrix()
        {
            int dimension;
            do
            {
                try
                {
                    // User input
                    Console.Write("Insert dimension: ");
                    dimension = Convert.ToInt32(Console.ReadLine());
                }
                // Failed cast string to int
                catch (FormatException)
                {
                    Console.WriteLine("Only numbers, try again...");
                    dimension = 0;
                }
            // Loop for 'right' dimension
            } while (dimension <= 0);
            // New matrix
            Matrix result = new Matrix(dimension);
            // Valid value flag
            bool valid;
            // Values 1 by 1
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    valid = false;
                    // Loop for 'right' value
                    do
                    {
                        try
                        {
                            // User input
                            Console.Write($"Value at ({i}, {j}): ");
                            result.SetAt(i, j,
                                         Convert.ToDouble(Console.ReadLine()));
                            // 'Right' value, continue for loops
                            valid = true;
                        }
                        // Failed cast string to int
                        catch (FormatException)
                        {
                            Console.WriteLine("Only numbers, try again...");
                        }
                    } while (!valid);
                }
            }
            return result;
        }

        // String representation
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
