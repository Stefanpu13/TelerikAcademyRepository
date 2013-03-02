using System;
using System.Linq;
using System.Numerics;
using System.Linq.Expressions;

namespace GenericMatrix
{
    class TestClass
    {
        internal static void ArithmeticsTestMethod<T>(string matrixType,Matrix<T> firstMatrix, Matrix<T> secondMatrix,
           Matrix<T> multiplicationMatrix)
        {
            Console.WriteLine("\n" + matrixType.ToUpper() +" TYPE\n");

            if (matrixType.ToUpper()=="DECIMAL")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Decimal type is intentionally not included in the list of allowed types" +
                    " due to testing purposes.");
                Console.ResetColor();   
            }
            
            #region
            // Addition
            #region
            Matrix<T> decimalResult = firstMatrix + secondMatrix;
            MatrixInfoDisplay( ArithmeticOperations.Addition,firstMatrix, secondMatrix, decimalResult);
            #endregion

            // Substraction
            #region
            decimalResult = firstMatrix - secondMatrix;
            MatrixInfoDisplay(ArithmeticOperations.Substraction,firstMatrix, secondMatrix, decimalResult);
            #endregion

            // Multiplication
            #region
            decimalResult = firstMatrix * multiplicationMatrix;
            MatrixInfoDisplay(ArithmeticOperations.Multiplication,
                firstMatrix, multiplicationMatrix, decimalResult);
            #endregion

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("-------------------------------------");
            #endregion
        }

        internal static void MultiplyMatrixWithNumber<T>(string matrixType, Matrix<T> matrix, T number)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nMultiply matrix with number".ToUpper());
            Console.ResetColor();

            Console.WriteLine("\n" + matrixType.ToUpper() + " TYPE\n");
            Console.WriteLine("Number: {0}\n", number);
            Console.WriteLine("Original matrix: ");
            PrintMatrix(matrix);

            Console.WriteLine("Result\n".ToUpper());
            PrintMatrix(matrix * number);
            Console.WriteLine("----------------------------");

        }

        private static void MatrixInfoDisplay<T>(ArithmeticOperations aritmeticAction, params Matrix<T>[] matrices)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(aritmeticAction);
            Console.ResetColor();

            // TODO: Find a way to get parameters names: string someParam = "str";
            // GetName(someParam) to return "someParam"

            PrintMatrixTitle("First matrix\n".ToUpper());
            PrintMatrix<T>(matrices[0]);

            PrintMatrixTitle("Second matrix\n".ToUpper());
            PrintMatrix(matrices[1]);

            PrintMatrixTitle("Result\n".ToUpper());
            PrintMatrix(matrices[2]);
            Console.WriteLine("----------------------------");

        }

        private static void PrintMatrixTitle(string title)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(title);
            Console.ResetColor();
        }

        private static void PrintMatrix<T>(Matrix<T> matrix)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(matrix.ToString());
            Console.ResetColor();
        }
    }
}
