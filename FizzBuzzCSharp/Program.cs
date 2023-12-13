namespace FizzBuzzCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running async FizzBuzz...");
            FizzBuzz.RunAsync();
        }
    }
    public class FizzBuzz
    {
        public static void Run(int start = 1, int end = 100, Dictionary<int, string> multiples = null)
        {
            //FizzBuzz will always run in ascending order, so swap the arguments if they are in the wrong positions
            if (end < start)
            {
                int temp = end;
                end = start;
                start = temp;
            }

            //If no custom arguments are provided, sensible defaults for the multiples dictionary are 'Fizz' and 'Buzz'
            if (multiples == null || multiples.Count == 0)
            {
                multiples = new Dictionary<int, string>
                {
                    { 3, "Fizz" },
                    { 5, "Buzz" }
                };
            }

            for (int i = start; i <= end; ++i)
            {
                string result = FizzBuzz.MultipleString(i, ref multiples);
                Console.WriteLine(result);
            }
        }

        public static async Task RunAsync(int start = 1, int end = 100, Dictionary<int, string> multiples = null)
        {
            //FizzBuzz will always run in ascending order, so swap the arguments if they are in the wrong positions
            if (end < start)
            {
                int temp = end;
                end = start;
                start = temp;
            }

            //If no custom arguments are provided, sensible defaults for the multiples dictionary are 'Fizz' and 'Buzz'
            if (multiples == null || multiples.Count == 0)
            {
                multiples = new Dictionary<int, string>
                {
                    { 3, "Fizz" },
                    { 5, "Buzz" }
                };
            }

            List<Task<string>> taskPool = new List<Task<string>>();
            for (int i = start; i <= end; ++i)
            {
                taskPool.Add(MultipleStringTask(i, multiples));
            }
            await Task.WhenAll(taskPool);
            foreach (var task in taskPool.ToArray())
            {
                Console.WriteLine($"{task.Result}");
            }
        }

        public static string MultipleString(int val, ref Dictionary<int, string> multiples)
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

        public static Task<string> MultipleStringTask(int val, Dictionary<int, string> multiples)
        {
            return Task<string>.Factory.StartNew(() =>
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
            });
        }
    }
}