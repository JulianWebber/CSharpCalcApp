using System;

class Program
{
    static void Main(string[] args)
    {
        Calculator calculator = new Calculator();

        Console.WriteLine("Welcome to the Simple Calculator!");
        Console.WriteLine("Running automated tests...");

        RunTest(calculator, 2, 3, "+", 5);
        RunTest(calculator, 10, 4, "-", 6);
        RunTest(calculator, 5, 6, "*", 30);
        RunTest(calculator, 20, 5, "/", 4);

        Console.WriteLine("Automated tests completed.");
        Console.WriteLine("Thank you for using the Simple Calculator. Goodbye!");
    }

    static void RunTest(Calculator calculator, double num1, double num2, string operation, double expectedResult)
    {
        try
        {
            double result = calculator.Calculate(num1, num2, operation);
            bool passed = Math.Abs(result - expectedResult) < 0.0001;
            Console.WriteLine($"Test: {num1} {operation} {num2} = {result} | Expected: {expectedResult} | {(passed ? "PASSED" : "FAILED")}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Test: {num1} {operation} {num2} | Error: {ex.Message}");
        }
    }
}
