using System;
using System.Linq;


namespace GenericMatrix
{
    internal static class SimpleArithmeticOperations<T>
    {
        //Just for demonstration on how to use generic delegate.
        public delegate Matrix<T> OpertationsDelegate<T>(Matrix<T> first, Matrix<T> second);

        internal static Matrix<T> PerformMatricesArithmeticOperation
            (Matrix<T> first, Matrix<T> second, ArithmeticOperations operation)
        {
            if (first != null && second != null)
            {
                Type matrixType = typeof(T);
                //Generic delegate object is declared after it is certain that an operation is possible.
                OpertationsDelegate<T> arithmetics;

                if (NumbersTypes.IsNumberType(matrixType))
                {
                    if (operation == ArithmeticOperations.Multiplication)
                    {
                        //Generic delegate object is initialised in the respective arithmetic case.
                        arithmetics = MultiplyMatrices;
                        return arithmetics(first, second);
                    }                    
                    else if (operation==ArithmeticOperations.Addition)
                    {
                        return AddMatrises(first, second);
                    }
                    else
                    {
                        return SubstractMatrises(first, second);
                    }
                }
                else
                {
                    string unsupportedTypeMessage = "The matrixes do not consist of numbers.";
                    throw new ArgumentException(unsupportedTypeMessage);
                }
            }
            else
            {
                // Creates message depending on which of the matrices is null.
                // See: http://pastebin.com/SdhNzHVU to understand how it works.
                string matrixNullMessage = first == null ?
                    (" first" + (second == null ? " and second matrices " : " matrix ")) :
                    ("" + (second == null ? " second matrix " : ""));

                string message = "The" + matrixNullMessage + "not initialised.";
                throw new NullReferenceException(message);
            }
        }

        private static Matrix<T> MultiplyMatrices(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
        {
            if (firstMatrix.Cols == secondMatrix.Rows)
            {
                Matrix<T> result = new Matrix<T>(firstMatrix.Rows, secondMatrix.Cols);

                for (int resultRow = 0; resultRow < firstMatrix.Rows; resultRow++)
                {
                    for (int resultCol = 0; resultCol < secondMatrix.Cols; resultCol++)
                    {
                        for (int commonCol = 0; commonCol < firstMatrix.Cols; commonCol++)
                        {
                            result[resultRow, resultCol] +=
                            (dynamic)firstMatrix[resultRow, commonCol] *
                            secondMatrix[commonCol, resultCol];
                        }
                    }
                }

                return result;
            }

            else
            {
                string message = "Matrixes can`t multiplied because first matrix height " +
                    " is not equal to second matrix width ";
                throw new InvalidOperationException(message);
            }
        }

        private static Matrix<T> AddMatrises(Matrix<T> first, Matrix<T> second)
        {
            if ((first.Rows == second.Rows && first.Cols == second.Cols))
            {
                T[,] newElements = (T[,])first.Elements.Clone();
                Matrix<T> result = new Matrix<T>(newElements);

                for (int row = 0; row < first.Rows; row++)
                {
                    for (int col = 0; col < first.Cols; col++)
                    {
                        result[row, col] += (dynamic)second[row, col];
                    }
                }

                return result;
            }
            else
            {
                string message = "Matrixes of different dimensions can`t be added.";
                throw new InvalidOperationException(message);
            }
        }

        private static Matrix<T> SubstractMatrises(Matrix<T> first, Matrix<T> second)
        {
           if (first.Rows == second.Rows && first.Cols == second.Cols)
            {
                T[,] newElements = (T[,])first.Elements.Clone();
                Matrix<T> result = new Matrix<T>(newElements);
                
                    for (int row = 0; row < first.Rows; row++)
                    {
                        for (int col = 0; col < first.Cols; col++)
                        {
                            result[row, col] -= (dynamic)second[row, col];
                        }
                    }
                    return result;
            }
           else
           {
               string message = "Matrixes of different dimensions can`t be substracted.";
               throw new InvalidOperationException(message);
           }
        }
    }
}
