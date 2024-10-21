namespace A_Calculator_Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to the calculator program");

            bool continueCalculating = true;

            while (continueCalculating)
            {
                int num1 = GetValidNumber("Please enter the first number:");
                int num2 = GetValidNumber("Please enter the second number:");

                char operation = GetValidOperation();
                int result = PerformCalculation(num1, num2, operation);

                Console.WriteLine($"Your result is: {result}");

                // Ask if the user wants to perform another operation
                continueCalculating = AskToContinue();
            }

            Console.WriteLine("Thank you for using the calculator program.");
            Console.ReadKey();
        }

        static int GetValidNumber(string message)
        {
            int number;
            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();
                if (int.TryParse(input, out number))
                {
                    return number;
                }
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }

        static char GetValidOperation()
        {
            char operation;
            while (true)
            {
                Console.WriteLine("What type of operation would you like to do?");
                Console.WriteLine("Please enter 'a' for addition, 's' for subtraction, 'm' for multiplication, or 'd' for division.");
                string input = Console.ReadLine().ToLower();

                if (input.Length == 1 && "asmd".Contains(input))
                {
                    operation = input[0];
                    return operation;
                }
                Console.WriteLine("Invalid operation. Please enter one of the specified characters.");
            }
        }

        static int PerformCalculation(int num1, int num2, char operation)
        {
            switch (operation)
            {
                case 'a':
                    return num1 + num2;
                case 's':
                    return num1 - num2;
                case 'm':
                    return num1 * num2;
                case 'd':
                    if (num2 == 0)
                    {
                        throw new DivideByZeroException("Cannot divide by zero.");
                    }
                    return num1 / num2;
                default:
                    throw new InvalidOperationException("Invalid operation.");
            }
        }

        static bool AskToContinue()
        {
            while (true)
            {
                Console.WriteLine("Would you like to perform another operation? (y/n)");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    return true;
                }
                else if (input == "n")
                {
                    return false;
                }
                Console.WriteLine("Invalid input. Please enter 'y' for yes or 'n' for no.");
            }
        }
    }
}
