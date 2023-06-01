using Labb_7;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_7_XUnit_Tests
{
    [Collection("Sequential")] // fixed the order of which the tests are done,
                               //This fixes and issue where many tests try to use the ConsoleClass-output at the same time.
    public class UserIntefaceTests
    {

        [Theory]
        [InlineData("You Choose Addition")]
        [InlineData("The Result is: 20")]
        public void Menu_ChoiceOne_Pass_Addition_String(string message)
        {
            // Arrange     
            var userInterface = new UserInterface();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // fake user input
            using (var stringReader = new StringReader("1\n10\n10")) // Inputs "Addition, and 10 + 10.
            {
                Console.SetIn(stringReader);
                // Act
                userInterface.Menu();
            }
            // Assert
            var consoleOutput = stringWriter.ToString();

            Assert.Contains(message, consoleOutput);
        }

        [Theory]
        [InlineData("You Choose Subtraction")]
        [InlineData("The Result is: 5")]
        public void Menu_ChoiceTwo_Should_Pass_Subtract_String(string message)
        {
            // Arrange     
            var userInterface = new UserInterface();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // fake user input
            using (var stringReader = new StringReader("2\n10\n5")) // Inputs the choice of subtract, and 10 - 5.
            {
                Console.SetIn(stringReader);
                // Act
                userInterface.Menu();
            }
            // Assert
            var consoleOutput = stringWriter.ToString();
            Assert.Contains(message, consoleOutput);
        }

        [Theory]
        [InlineData("You Choose Multiplication")]
        [InlineData("The Result is: 100")]
        public void Menu_ChoiceThree_Should_Pass_Multiply_String(string message)
        {
            // Arrange     
            var userInterface = new UserInterface();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // fake user input
            using (var stringReader = new StringReader("3\n25\n4")) // Inputs the choice of Multiply, and 25 * 4
            {
                Console.SetIn(stringReader);
                // Act
                userInterface.Menu();
            }
            // Assert
            var consoleOutput = stringWriter.ToString();
            Assert.Contains(message, consoleOutput);
        }

        [Theory]
        [InlineData("You Choose Division")]
        [InlineData("The Result is: 6")]
        public void Menu_ChoiceFour_Should_Pass_Division_String(string message)
        {
            // Arrange     
            var userInterface = new UserInterface();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // fake user input
            using (var stringReader = new StringReader("4\n36\n6")) // Inputs the choice of Division, and 36 / 6
            {
                Console.SetIn(stringReader);
                // Act
                userInterface.Menu();
            }
            // Assert
            var consoleOutput = stringWriter.ToString();
            Assert.Contains(message, consoleOutput);
        }


        [Fact]
        public void Menu_ChoiceFive_Should_Start_PrintLogsFunction()
        {
            // Arrange     
            var userInterface = new UserInterface();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // fake user input
            using (var stringReader = new StringReader("5")) // Inputs the choice of Division, and 36 / 6
            {
                Console.SetIn(stringReader);
                // Act
                userInterface.Menu();
            }
            // Assert
            var consoleOutput = stringWriter.ToString();
            Assert.Contains("All Logged Calculations", consoleOutput);
        }
        [Fact]
        public void Menu_NotExist_Should_Send_DefaulMessage()
        {
            // Arrange     
            var userInterface = new UserInterface();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            // fake user input
            using (var stringReader = new StringReader("100")) // a value without a switch case
            {
                Console.SetIn(stringReader);
                // Act
                userInterface.Menu();
            }
            // Assert
            var consoleOutput = stringWriter.ToString();
            Assert.Contains("Input a relevant number and try again", consoleOutput);
        }

        [Fact]
        public void Menu_WrongValueType_Should_Give_ExceptionMessage()
        {
            // Arrange
            var userInterface = new UserInterface();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            using (var stringReader = new StringReader("s")) // simulate incorrect input
            {
                Console.SetIn(stringReader);

                // Act
                userInterface.Menu();
            }

            // Assert
            var output = stringWriter.ToString();
            Assert.Contains("Choose an action with the number keys", output);

        }



        ///////////////////////////////////////////////////////////////////////////////////////
        ///


        [Fact]
        public void CalculatorInput_AdditionWithValidInput_ShouldCalculateSum()
        {
            // Arrange
            var userInterface = new UserInterface();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            using (var stringReader = new StringReader("10\n10"))
            {
                Console.SetIn(stringReader);

                // Act
                userInterface.CalculatorInput("Addition");
            }

            // Assert
            var output = stringWriter.ToString();
            Assert.Contains("The Result is: 20", output);

        }
        [Fact]
        public void CalculatorInput_SubtractionWithValidInput_ShouldCalculateSum()
        {
            // Arrange
            var userInterface = new UserInterface();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            using (var stringReader = new StringReader("10\n5"))
            {
                Console.SetIn(stringReader);

                // Act
                userInterface.CalculatorInput("Subtract");
            }

            // Assert
            var output = stringWriter.ToString();
            Assert.Contains("The Result is: 5", output);

        }

        [Fact]
        public void CalculatorInput_MultiplayWithValidInput_ShouldCalculateSum()
        {
            // Arrange
            var userInterface = new UserInterface();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            using (var stringReader = new StringReader("10\n5"))
            {
                Console.SetIn(stringReader);

                // Act
                userInterface.CalculatorInput("Multiply");
            }

            // Assert
            var output = stringWriter.ToString();
            Assert.Contains("The Result is: 50", output);

        }

        [Fact]
        public void CalculatorInput_DivisionWithValidInput_ShouldCalculateSum()
        {
            // Arrange
            var userInterface = new UserInterface();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            using (var stringReader = new StringReader("10\n5"))
            {
                Console.SetIn(stringReader);

                // Act
                userInterface.CalculatorInput("Division");
            }

            // Assert
            var output = stringWriter.ToString();
            Assert.Contains("The Result is: 2", output);

        }

        [Fact]
        public void CalculatorInput_FirstValueInvalidInput_Should_AbortCalcultion()
        {
            // Arrange
            var userInterface = new UserInterface();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            using (var stringReader = new StringReader("s\n5")) // First value is invalid
            {
                Console.SetIn(stringReader);

                // Act
                userInterface.CalculatorInput("Subtract");
            }

            // Assert
            var output = stringWriter.ToString();
            Assert.Contains("Wrong input, calculation aborted", output);

        }
        [Fact]
        public void CalculatorInput_SecondValueInvalidInput_Should_AbortCalcultion()
        {
            // Arrange
            var userInterface = new UserInterface();
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            using (var stringReader = new StringReader("10\nasd")) // First value is invalid
            {
                Console.SetIn(stringReader);

                // Act
                userInterface.CalculatorInput("Subtract");
            }

            // Assert
            var output = stringWriter.ToString();
            Assert.Contains("Wrong input, calculation aborted", output);

        }
    }
}

