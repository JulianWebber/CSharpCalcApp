using System;

class Program
{
    static void Main(string[] args)
    {
        Calculator calculator = new Calculator();
        bool continueCalculating = true;

        Console.WriteLine("Welcome to the Advanced Calculator!");

        while (continueCalculating)
        {
            try
            {
                Console.WriteLine("\nPlease enter the operation (+, -, *, /, sqrt, ^):");
                string? operation = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(operation))
                {
                    throw new ArgumentException("Operation cannot be empty.");
                }

                double num1, num2 = 0;

                if (operation.ToLower() == "sqrt")
                {
                    Console.WriteLine("Please enter the number:");
                    if (!double.TryParse(Console.ReadLine(), out num1))
                    {
                        throw new FormatException("Invalid number format.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter the first number:");
                    if (!double.TryParse(Console.ReadLine(), out num1))
                    {
                        throw new FormatException("Invalid number format.");
                    }

                    if (operation != "sqrt")
                    {
                        Console.WriteLine("Please enter the second number:");
                        if (!double.TryParse(Console.ReadLine(), out num2))
                        {
                            throw new FormatException("Invalid number format.");
                        }
                    }
                }

                double result = calculator.Calculate(num1, num2, operation);
                Console.WriteLine($"Result: {result}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide by zero.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine("An unexpected error occurred.");
            }

            Console.WriteLine("\nDo you want to perform another calculation? (y/n)");
            string? answer = Console.ReadLine()?.ToLower();
            continueCalculating = (answer == "y" || answer == "yes");
        }

        Console.WriteLine("\nRunning automated tests...");

        RunTest(calculator, 2, 3, "+", 5);
        RunTest(calculator, 10, 4, "-", 6);
        RunTest(calculator, 5, 6, "*", 30);
        RunTest(calculator, 20, 5, "/", 4);
        RunTest(calculator, 16, 0, "sqrt", 4);
        RunTest(calculator, 2, 3, "^", 8);

        Console.WriteLine("Automated tests completed.");
        Console.WriteLine("Thank you for using the Advanced Calculator. Goodbye!");
    }

    static void RunTest(Calculator calculator, double num1, double num2, string operation, double expectedResult)
    {
        try
        {
            double result = calculator.Calculate(num1, num2, operation);
            bool passed = Math.Abs(result - expectedResult) < 0.0001;
            Console.WriteLine($"Test: {num1} {operation} {(operation == "sqrt" ? "" : num2.ToString())} = {result} | Expected: {expectedResult} | {(passed ? "PASSED" : "FAILED")}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Test: {num1} {operation} {num2} | Error: {ex.Message}");
        }
    }
}
