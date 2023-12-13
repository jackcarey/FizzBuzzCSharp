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
                    Console.WriteLine("Using 1 for 'start'. Error: " + e.Message);
                    start = 1;
                }
                try
                {
                    if (args.Length >= 1)
                    {
                        int endArg = int.Parse(args[0]);
                        if (endArg <= 0)
                        {
                            throw new FormatException("'start' must be greater than 0.");
                        }
                        if (endArg <= start)
                        {
                            throw new Exception("'end' must be greater than 'start'.");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Adding 100 to 'start' for 'end'. Error: " + e.Message);
                    end = start + 100;
                }
                if (args.Length >= 2)
                {
                    multiples.Clear();
                    for (var i = 2; i < args.Length; ++i)
                    {
                        try
                        {
                            string[] splitArg = args[i].Split('=');
                            multiples.Add(int.Parse(splitArg[0]), splitArg[1]);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Argument '{0}' could not be parsed, skipping. Error: {1}", args[i], e.Message);
                        }
                    }
                }
            }
            for (int i = start; i <= end; ++i)
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
