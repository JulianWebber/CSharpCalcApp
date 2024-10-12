using System;

public class Calculator
{
    public double Calculate(double num1, double num2, string operation)
    {
        switch (operation)
        {
            case "+":
                return Add(num1, num2);
            case "-":
                return Subtract(num1, num2);
            case "*":
                return Multiply(num1, num2);
            case "/":
                return Divide(num1, num2);
            case "sqrt":
                return SquareRoot(num1);
            case "^":
                return Power(num1, num2);
            default:
                throw new ArgumentException("Invalid operation. Please use +, -, *, /, sqrt, or ^.");
        }
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
}
