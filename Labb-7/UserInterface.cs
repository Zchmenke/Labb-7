using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_7
{
    public class UserInterface
    {
        Calculator calculator = new Calculator();
        public void Menu()
        {
            var menuBool = true;
            while (menuBool == true)
            {
                Console.WriteLine(
                    "\n\t----Choose Action----" +
                    "\n\t---------------------" +
                    "\n\t[1] - Addition" +
                    "\n\t[2] - Subtraction" +
                    "\n\t[3] - Multiplication" +
                    "\n\t[4] - Division" +
                    "\n\t[5] - View log");

                var userChoice = 0;
                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("\n\t Choose an action with the number keys");
                    
                   
                }

                switch (userChoice)
                {
                    case 0:
                        menuBool = false;
                        break;
                    case 1:
                        Console.WriteLine("You Choose Addition");
                        CalculatorInput("Addition");
                        break;
                    case 2:
                        Console.WriteLine("You Choose Subtraction");
                        CalculatorInput("Subtract");
                        break;
                    case 3:
                        Console.WriteLine("You Choose Multiplication");
                        CalculatorInput("Multiply");
                        break;
                    case 4:
                        Console.WriteLine("You Choose Division");
                        CalculatorInput("Division");
                        break;
                    case 5:

                        calculator.PrintLog();
                        break;
                    default:
                        Console.WriteLine("Input a relevant number and try again");
                        break;
                }
            }


        }
        public void CalculatorInput(string calculatorChoice)
        {
            int a = 0;
            int b = 0;
            Console.WriteLine("\n\tInput the first value : ");
            try
            {
                a = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("\n\t Wrong input, calculation aborted");
                return;
            }

            Console.WriteLine("\n\tInput the second value : ");
            try
            {
                b = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("\n\t Wrong input, calculation aborted");
                return;
            }

            switch (calculatorChoice)
            {
                case "Addition":
                    calculator.Add(a, b);
                    break;
                case "Subtract":
                    calculator.Subtract(a, b);
                    break;
                case "Multiply":
                    calculator.Multiply(a, b);
                    break;
                case "Division":
                    calculator.Divide(a, b);
                    break;
                default:
                    Console.WriteLine("Something went wrong");

                    break;
            }


        }
    }
}
