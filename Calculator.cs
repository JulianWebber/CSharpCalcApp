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
            default:
                throw new ArgumentException("Invalid operation. Please use +, -, *, or /.");
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
}
