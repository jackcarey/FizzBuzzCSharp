namespace FizzBuzzCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            Dictionary<int, string> multiples = new()
            {
                [3] = "Fizz",
                [5] = "Buzz"
            };
            if (args.Length > 0)
            {
                try
                {
                    int startArg = int.Parse(args[0]);
                    if (startArg <= 0)
                    {
                        throw new FormatException("'start' must be greater than 0.");
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Using 1 for start. Error: " + e.Message);
                }
            }
            for (int i = start; i < end; ++i)
            {
                string result = MultipleString(ref i, ref multiples);
                Console.WriteLine(result);
            }
        }

        static string MultipleString(ref int val, ref Dictionary<int, string> multiples)
        {
            string resultStr = "";
            foreach (var multiple in multiples)
            {
                if (val % multiple.Key == 0)
                {
                    resultStr += multiple.Value;
                }
            }
            if (resultStr.Length == 0)
            {
                resultStr = val.ToString();
            }
            return resultStr;
        }
    }
}
