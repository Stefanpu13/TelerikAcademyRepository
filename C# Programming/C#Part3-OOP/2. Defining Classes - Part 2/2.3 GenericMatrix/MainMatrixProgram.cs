using System;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Globalization;

namespace GenericMatrix
{
    class MainMatrixProgram
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            // Double matrices
            #region
            double[,] firstDoubleArray = { { 2.3, 3 }, { 4, 5.6 }, { 6, 7 } };
            double[,] secondDoubleArray = { { 2, 2 }, { 2, 2 }, { 2, 2 } };
            double[,] doubleMultiplicationArray = { { 2, 2, 5 }, { 3.4, 3, 1 } };

            Matrix<double> firstDoubleMatrix = new Matrix<double>(firstDoubleArray);
            Matrix<double> secondDoubleMatrix = new Matrix<double>(secondDoubleArray);
            Matrix<double> multiplicationMatrix = new Matrix<double>(doubleMultiplicationArray);

            TestClass.ArithmeticsTestMethod("double", firstDoubleMatrix, secondDoubleMatrix, multiplicationMatrix);
            #endregion

            // Int matrices
            #region
            int[,] firstIntArray = { { 2, 3 }, { 4, 5 }, { 6, 7 } };
            int[,] secondIntArray = { { 2, 4 }, { 2, 2 }, { 2, 2 } };
            int[,] intMultiplicationArray = { { 2, 2, 5 }, { 3, 3, 1 } };

            Matrix<int> firstIntMatrix = new Matrix<int>(firstIntArray);
            Matrix<int> secondIntMatrix = new Matrix<int>(secondIntArray);
            Matrix<int> intMultiplicationMatrix = new Matrix<int>(intMultiplicationArray);

            TestClass.ArithmeticsTestMethod("int", firstIntMatrix, secondIntMatrix, intMultiplicationMatrix);
            #endregion

            // Decimal matrices. Decimal intentionally not included in the "NumbersTypes" class
            // For displaying purposes.
            #region
            decimal[,] firstDecimalArray = { { 2.34M, 3 }, { 4, 5 }, { 6.34m, 7.55M } };
            decimal[,] secondDecimalArray = { { 2, 2 }, { 2, 2 }, { 2, 2.56m } };
            decimal[,] decimalMultiplicationArray = { { 2, 2, 5 }, { 3, 3, 1 } };

            Matrix<Decimal> firstDecimalMatrix = new Matrix<Decimal>(firstDecimalArray);
            Matrix<Decimal> secondDecimalMatrix = new Matrix<Decimal>(secondDecimalArray);
            Matrix<Decimal> decimalMultiplicationMatrix = new Matrix<Decimal>(decimalMultiplicationArray);

            try
            {
                TestClass.ArithmeticsTestMethod("decimal",firstDecimalMatrix, secondDecimalMatrix,
                    decimalMultiplicationMatrix);
            }
            catch (ArgumentException ae)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("--------------");
                Console.WriteLine(ae.Message);
                Console.WriteLine("--------------");
                Console.ResetColor();
            }
            #endregion

            // BigInteger matrices.           
            #region
            BigInteger[,] firstBigIntegerArray = { { -4, 3 }, { 4, 5 }, { 6, 7 } };
            BigInteger[,] secondBigIntegerArray = { { 2, 2 }, { 2, 2 }, { 2, 2 } };
            BigInteger[,] bigIntegerMultiplicationArray = { { 2, 2, 5 }, { 3, 3, 1 } };

            Matrix<BigInteger> firstBigIntegerMatrix = new Matrix<BigInteger>(firstBigIntegerArray);
            Matrix<BigInteger> secondBigIntegerMatrix = new Matrix<BigInteger>(secondBigIntegerArray);
            Matrix<BigInteger> bigIntegerMultiplicationMatrix =
                new Matrix<BigInteger>(bigIntegerMultiplicationArray);


            TestClass.ArithmeticsTestMethod("BigInteger", firstBigIntegerMatrix, secondBigIntegerMatrix,
                bigIntegerMultiplicationMatrix);
            #endregion

            // Complex matrices.           
            #region
            Complex[,] firstComplexArray = { {new Complex( -4, 3), new Complex(2,2.5) },
                                           {new Complex( 4, 5.7),new Complex( 1, -5.2) },
                                           {new Complex( 4,2),new Complex( 33, 0)} };
            
            Complex[,] secondComplexArray = { {new Complex( 2, 2), new Complex(2,2) },
                                           {new Complex( 2, 2), new Complex( 2, 2) },
                                           {new Complex( 2, 2), new Complex( 2, 2)} };


            Complex[,] complexMultiplicationArray = { { new Complex(2, 2), new Complex(2, 2),
                                                          new Complex(1, -5.2) },
                                                    {new Complex(3, 1), new Complex(0, 1),
                                                          new Complex(1, -0.2) } };

            Matrix<Complex> firstComplexMatrix = new Matrix<Complex>(firstComplexArray);
            Matrix<Complex> secondComplexMatrix = new Matrix<Complex>(secondComplexArray);
            Matrix<Complex> complexMultiplicationMatrix =
                new Matrix<Complex>(complexMultiplicationArray);


            TestClass.ArithmeticsTestMethod("complex", firstComplexMatrix, secondComplexMatrix,
                complexMultiplicationMatrix);
            #endregion

            // DateTime matrices.
            #region
            DateTime[,] firstDateTimeArray = { { DateTime.Now, DateTime.UtcNow }, 
                                             { DateTime.UtcNow , DateTime.Now },
                                            {DateTime.Now, DateTime.UtcNow } };

            DateTime[,] secondDateTimeArray = { { DateTime.Now, DateTime.UtcNow  }, 
                                              {  DateTime.UtcNow , DateTime.Now },
                                             { DateTime.Now, DateTime.UtcNow } };
            DateTime[,] dateTimeMultiplicationArray = { { DateTime.Now, DateTime.UtcNow ,DateTime.Now}, 
                                                     { DateTime.Now, DateTime.UtcNow ,DateTime.Now} };

            Matrix<DateTime> firstDateTimeMatrix = new Matrix<DateTime>(firstDateTimeArray);
            Matrix<DateTime> secondDateTimeMatrix = new Matrix<DateTime>(secondDateTimeArray);
            Matrix<DateTime> dateTimeMultiplicationMatrix = new Matrix<DateTime>(dateTimeMultiplicationArray);

            try
            {
                TestClass.ArithmeticsTestMethod("DateTime", firstDateTimeMatrix, secondDateTimeMatrix,
                    dateTimeMultiplicationMatrix);
            }
            catch (ArgumentException ae)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("--------------");
                Console.WriteLine(ae.Message);
                Console.WriteLine("--------------");
                Console.ResetColor();
            }
            #endregion

            // Matrix Mutiplication with number
            TestClass.MultiplyMatrixWithNumber("int", firstIntMatrix, 2);
        }

       
    }

   
}
