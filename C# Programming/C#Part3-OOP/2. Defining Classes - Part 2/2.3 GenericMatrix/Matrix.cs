using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{   

    

    class Matrix<T>
    {
        

        public Matrix(int rows, int columns)
        {
            this.Elements = new T[rows, columns];
            this.Rows = rows;
            this.Cols = columns;
        }

        public Matrix(T[,] array)
        {
            this.Elements = array;
            this.Rows = array.GetLength(0);
            this.Cols = array.GetLength(1);
        }


        public T[,] Elements { get; set; }

        public int Rows { get; set; }

        public int Cols { get; set; }


        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {           
                Matrix<T> result =
                SimpleArithmeticOperations<T>.
                PerformMatricesArithmeticOperation(first, second, ArithmeticOperations.Addition);

                return result;          
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            Matrix<T> result =
            SimpleArithmeticOperations<T>.
            PerformMatricesArithmeticOperation(first, second, ArithmeticOperations.Substraction);

            return result;
        }

        // First method for multiplication with number.
        // Will mutiply "number * matrix" but not "matrix * number" due to method signature.
        public static Matrix<T> operator *(T number, Matrix<T> matrix)
        {
            Type matrixType = typeof(T);
            T[,] newElements = (T[,])matrix.Elements;
            Matrix<T> result = new Matrix<T>(newElements);

            for (int row = 0; row < matrix.Rows; row++)
            {
                for (int col = 0; col < matrix.Cols; col++)
                {
                    result[row, col] *= (dynamic)number;
                }
            }

            return result;
        }

        // Overloaded method for multiplication with number
        // If this method is not implemented, then "Matrix" * "number"(parameter order is important!!!)
        // will give compilation error. Why? 
        // Because "string SomeMethod(string str, char ch)" != "string SomeMethod( char ch, string str)"  
        public static Matrix<T> operator *(Matrix<T> matrix, T number)
        {
            return number * matrix;
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            
                Matrix<T> result =
                SimpleArithmeticOperations<T>.
                PerformMatricesArithmeticOperation(first, second, ArithmeticOperations.Multiplication);
                return result;
           
        }

        // The way I understand it, the task is to return true if at least one element is not zero or null.
        public static bool operator true(Matrix<T> matrix)  
        {
            foreach (var item in matrix.Elements)
            {
                
                if (!item.Equals(null) && !item.Equals(default(T)))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator false(Matrix<T> matrix) 
        {
            //Alternatively:
            //return matrix.Equals(true);
            foreach (var item in matrix.Elements)
            {
                if (item.Equals(null) || item.Equals(default(T)))
                {
                    return true;
                }
            }
            return false;
        }

        internal T this[int row, int col]
        {
            get 
            {
                if ((row < 0 || row >= this.Rows) || (col<0 || col>this.Cols))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    return Elements[row, col];
                }                
            }
            
            set 
            {
                if ((row < 0 || row >= this.Rows) || (col < 0 || col > this.Cols))
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    Elements[row, col] = value;
                } 
            }
        }

        public override string ToString()
        {
            StringBuilder matrixString = new StringBuilder();
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                { 
                    matrixString.Append(string.Format("{0,6:0.##}", Elements[row, col]) + " ");
                }
               
                matrixString.AppendLine("\n");
            }

            return matrixString.ToString();
        }
    }
}
