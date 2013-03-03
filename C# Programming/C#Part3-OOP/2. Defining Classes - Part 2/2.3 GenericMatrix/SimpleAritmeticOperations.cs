using System;
using System.Linq;


namespace GenericMatrix
{
    internal static class SimpleArithmeticOperations<T>
    {
        internal static Matrix<T> PerformMatricesArithmeticOperation
            (Matrix<T> first, Matrix<T> second, ArithmeticOperations operation)
        {
            Type matrixType = typeof(T);

            if (first != null && second != null)
            {
                if (NumbersTypes.IsNumberType(matrixType))
                {
                    if (operation == ArithmeticOperations.Multiplication)
                    {
                        return MultiplyMatrices(first, second);
                    }
                    // If adding or substracting
                    else
                    {
                        return PerformAdditionOrSubstraction(first, second, operation);
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

        private static Matrix<T> PerformAdditionOrSubstraction(Matrix<T> first, Matrix<T> second, ArithmeticOperations operation)
        {
            if ((first.Rows == second.Rows && first.Cols == second.Cols))
            {
                Matrix<T> result = operation == ArithmeticOperations.Addition ?
                    AddMatrises(first, second) :
                    SubstractMatrises(first, second);

                return result;
            }

            else
            {
                //A message is generated, depending on action to be performed.
                string arithmeticAction = operation == ArithmeticOperations.Addition ?
                    " added." : " substracted.";
                string message = "Matrixes of different dimensions can`t be" +
                    arithmeticAction;

                throw new InvalidOperationException(message);
            }
        }

        private static Matrix<T> MultiplyMatrices(Matrix<T> firstMatrix, Matrix<T> secondMatrix)
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

        private static Matrix<T> AddMatrises(Matrix<T> first, Matrix<T> second)
        { 
                T[,] newElements = (T[,])first.Elements.Clone();
                Matrix<T> result = new Matrix<T>(newElements);
                
                for (int row = 0; row < first.Rows; row++)
                {
                    for (int col = 0; col < first.Cols; col++)
                    {
                         result[row, col] +=  (dynamic)second[row, col];
                    }
                }                

                return result;
            
          
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
