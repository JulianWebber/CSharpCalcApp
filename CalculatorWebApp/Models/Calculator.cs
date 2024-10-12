using System;
using System.Collections.Generic;

namespace CalculatorWebApp.Models
{
    public class Calculator
    {
        private double memoryValue = 0;
        private List<string> history = new List<string>();

        public double Calculate(double num1, double num2, string operation)
        {
            double result;
            switch (operation)
            {
                case "+":
                    result = Add(num1, num2);
                    break;
                case "-":
                    result = Subtract(num1, num2);
                    break;
                case "*":
                    result = Multiply(num1, num2);
                    break;
                case "/":
                    result = Divide(num1, num2);
                    break;
                case "sqrt":
                    result = SquareRoot(num1);
                    break;
                case "^":
                    result = Power(num1, num2);
                    break;
                case "M+":
                    result = MemoryAdd(num1);
                    break;
                case "MR":
                    result = MemoryRecall();
                    break;
                case "MC":
                    MemoryClear();
                    result = 0;
                    break;
                default:
                    throw new ArgumentException("Invalid operation. Please use +, -, *, /, sqrt, ^, M+, MR, or MC.");
            }

            history.Add($"{num1} {operation} {(operation == "sqrt" || operation == "M+" || operation == "MR" || operation == "MC" ? "" : num2.ToString())} = {result}");

            return result;
        }

        public List<string> GetHistory()
        {
            return history;
        }

        public void ClearHistory()
        {
            history.Clear();
        }

        private double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        private double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        private double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        private double Divide(double num1, double num2)
        {
            if (num2 == 0)
            {
                throw new DivideByZeroException();
            }
            return num1 / num2;
        }

        private double SquareRoot(double num)
        {
            if (num < 0)
            {
                throw new ArgumentException("Cannot calculate square root of a negative number.");
            }
            return Math.Sqrt(num);
        }

        private double Power(double baseNum, double exponent)
        {
            return Math.Pow(baseNum, exponent);
        }

        private double MemoryAdd(double num)
        {
            memoryValue += num;
            return memoryValue;
        }

        private double MemoryRecall()
        {
            return memoryValue;
        }

        private void MemoryClear()
        {
            memoryValue = 0;
        }
    }
}