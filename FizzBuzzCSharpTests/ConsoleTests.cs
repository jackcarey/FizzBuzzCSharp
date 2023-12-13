using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzzCSharp;

namespace FizzBuzzTests
{
    [TestClass]
    public class ConsoleOutputTests
    {
        [TestMethod]
        public void TestDefault()
        {
            using (var sw = new StringWriter())
            {
                //Override the default output so this test can check the result
                Console.SetOut(sw);
                Console.SetError(sw);
                FizzBuzz.Run();
                string[] result = sw.ToString().Split(Environment.NewLine).Take(5).ToArray();
                string[] correctResult = { "1", "2", "Fizz", "4", "Buzz" };
                CollectionAssert.AreEqual(result, correctResult);
            }
        }
    }
}