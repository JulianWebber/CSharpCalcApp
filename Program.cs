using System;

class Program
{
    static void Main(string[] args)
    {
        Calculator calculator = new Calculator();
        bool continueCalculating = true;

        Console.WriteLine("Welcome to the Simple Calculator!");

        while (continueCalculating)
        {
            try
            {
                Console.WriteLine("\nPlease enter the first number:");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Please enter the operation (+, -, *, /):");
                string operation = Console.ReadLine();

                Console.WriteLine("Please enter the second number:");
                double num2 = Convert.ToDouble(Console.ReadLine());

                double result = calculator.Calculate(num1, num2, operation);
                Console.WriteLine($"Result: {result}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid number format. Please enter valid numbers.");
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
            string answer = Console.ReadLine().ToLower();
            continueCalculating = (answer == "y" || answer == "yes");
        }

        Console.WriteLine("Thank you for using the Simple Calculator. Goodbye!");
    }
}
