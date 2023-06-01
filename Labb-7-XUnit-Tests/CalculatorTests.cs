using Labb_7;
using Shouldly;
using Xunit.Sdk;

namespace Labb_7_XUnit_Tests
{
    [Collection("Sequential")]
    public class CalculatorTests
    {

        [Fact]  //Addition
        public void Add_Should_Return_CorrectValue()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            var actual = calculator.Add(10, 10);
            var expected = 20;

            //Assert
            Assert.Equal(expected, actual);

        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        [Fact] //Subtraction
        public void Subtract_Should_Return_CorrectValue()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            var actual = calculator.Subtract(100, 50);
            var expected = 50;

            //Assert
            Assert.Equal(expected, actual);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Fact] //Multiplication
        public void Multiply_Should_Return_CorrectValue()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            var actual = calculator.Multiply(5, 5);
            var expected = 25;

            //Assert
            Assert.Equal(expected, actual);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        [Fact] //Division
        public void Divide_Should_Return_CorrectValue()
        {
            //Arrange
            Calculator calculator = new Calculator();

            //Act
            var actual = calculator.Divide(100, 5);
            var expected = 20;

            //Assert
            Assert.Equal(expected, actual);
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Theory]
        [InlineData(10, 20)]
        public void PrintResult_Should_Print_Sum(int a, int b)
        {
            //Arrange
            Calculator calculator = new Calculator();
            var originalOutput = Console.Out; // storing the consoles output
            string expected = $"\n\tThe Result is: {a + b}" + Environment.NewLine;

            using (var output = new StringWriter())
            {
                Console.SetOut(output);

                //Act
                calculator.PrintResult(a + b);


                //Assert
                string actual = output.ToString();
                Assert.Equal(expected, actual);
            }
            Console.SetOut(originalOutput); // resetting the consoles output after using it or the tests will crash.
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////

        [Theory]
        [InlineData(5, 5, 10, "Add")] // Addition logs
        public void Log_Should_Add_Addition_To_List(int a, int b, int sum, string functionName)
        {
            //Arrange
            Calculator calculator = new Calculator();
            //Act
            calculator.Log(a, b, sum, functionName);
            //Arrange
            Assert.Contains("5 + 5 = 10", calculator.LogList);
            calculator.LogList.ShouldContain("5 + 5 = 10");
        }
        [Theory]
        [InlineData(10, 5, 5, "Subtract")] // Subtraction Logs
        public void Log_Should_Add_Subtraction_To_List(int a, int b, int sum, string functionName)
        {
            //Arrange
            Calculator calculator = new Calculator();
            //Act
            calculator.Log(a, b, sum, functionName);
            //Assert           
            calculator.LogList.ShouldContain("10 - 5 = 5");

        }
        [Theory]
        [InlineData(10, 5, 50, "Multiply")] // Multiply Logs
        public void Log_Should_Add_Multiply_To_List(int a, int b, int sum, string functionName)
        {
            //Arrange
            Calculator calculator = new Calculator();
            //Act
            calculator.Log(a, b, sum, functionName);
            //Assert           
            calculator.LogList.ShouldContain("10 * 5 = 50");

        }
        [Theory]
        [InlineData(124, 2, 62, "Divide")] // Multiply Logs
        public void Log_Should_Add_Divide_To_List(int a, int b, int sum, string functionName)
        {
            //Arrange
            Calculator calculator = new Calculator();
            //Act
            calculator.Log(a, b, sum, functionName);
            //Assert           
            calculator.LogList.ShouldContain("124 / 2 = 62");

        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        [Fact]
        public void PrintLog_Should_Print_AllLogs_In_LogList()
        {
            //Arrange 
            Calculator calculator = new Calculator();
            calculator.Log(100, 50, 150, "Add");
            calculator.Log(1000, 500, 500, "Subtract");
            calculator.Log(2, 2, 4, "Multiply");
            calculator.Log(50, 10, 5, "Divide");
            var originalOutput = Console.Out; // storing the consoles output

            using (var output = new StringWriter())
            {
                Console.SetOut(output);
                calculator.PrintLog();
                //Assert
                string actual = output.ToString();
                string expected = "---All Logged Calculations---\r\n" +
                  "\n\t100 + 50 = 150\r\n" +
                  "\n\t1000 - 500 = 500\r\n" +
                  "\n\t2 * 2 = 4\r\n" +
                  "\n\t50 / 10 = 5";

                Assert.Equal(expected, actual.Trim());
            }
            Console.SetOut(originalOutput);
        }
    }
}