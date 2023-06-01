using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Labb_7
{
    public class Calculator
    {


        public List<string> LogList;
        public Calculator()
        {
            LogList = new List<string>();
        }
        //Addition
        public int Add(int a, int b)
        {
            var sum = a + b;
            Log(a, b, sum, "Add");
            PrintResult(sum);
            return sum;
        }
        //Subtract
        public int Subtract(int a, int b)
        {
            int sum = a - b;
            Log(a, b, sum, "Subtract");
            PrintResult(sum);
            return a - b;
        }
        //Multiply
        public int Multiply(int a, int b)
        {
            int sum = a * b;
            Log(a, b, sum, "Multiply");
            PrintResult(sum);
            return a * b;
        }
        //Division
        public int Divide(int a, int b)
        {
            int sum = a / b;
            Log(a, b, sum, "Divide");
            PrintResult(sum);
            return a / b;
        }
        //Prints the result
        public void PrintResult(int sum)
        {
            Console.WriteLine("\n\tThe Result is: " + sum);
          
        }

        // Log all Calculations
        public void Log(int a, int b, int sum, string functionName)
        {
            switch (functionName)
            {
                case "Add":
                    LogList.Add($"{a} + {b} = {sum}");
                    break;
                case "Subtract":
                    LogList.Add($"{a} - {b} = {sum}");
                    break;
                case "Multiply":
                    LogList.Add($"{a} * {b} = {sum}");
                    break;
                case "Divide":
                    LogList.Add($"{a} / {b} = {sum}");
                    break;
            }

        }
        // Print the logs
        public void PrintLog()
        {
          
            Console.WriteLine("\n\t---All Logged Calculations---");
            foreach (var Log in LogList)
            {

                Console.WriteLine($"\n\t{Log}");

            }

        }
    }
}
