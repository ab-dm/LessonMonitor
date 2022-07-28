namespace Lessons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ElvisOperator();

        }

        public static void ElvisOperator()
        {
            int? number = 1;
            int? number1 = null;

            Console.WriteLine(number.Value);
            Console.WriteLine(number1);
        }

        private static void PrintDefault()
        {
            int number = default(int);
            int? nullableNumber = default(int);
            int? nullableNumber1 = default(int?);

            Console.WriteLine(number);
            Console.WriteLine(nullableNumber);
            Console.WriteLine(nullableNumber1);

            string text = default(string);
            string? nullableText  = default(string);
            string? nullableText1 = default(string);

            Console.WriteLine(text);
            Console.WriteLine(nullableText);
            Console.WriteLine(nullableText1);
        }

        public static void PrintString()
        {
            string str = "";
            string str1 = str ?? "";
            Console.WriteLine(str1);
        }

        public static void PrintNumber()
        {
            int? nullableNumber = null;
            int number = nullableNumber.HasValue ? nullableNumber.Value : default(int);
            int number1 = nullableNumber ?? 1;
            int number2 = nullableNumber.GetValueOrDefault(2);
            Console.WriteLine(nullableNumber);
            Console.WriteLine(number);
            Console.WriteLine(number1);
            Console.WriteLine(number2);
        }
    }
     
}