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
                string[] correctResult = { "1", "2", "Fizz", "4", "Buzz","Fizz","7","8","Fizz","Buzz","11","Fizz","13","14","FizzBuzz" };
                string[] result = sw.ToString().Split(Environment.NewLine).Take(correctResult.Length).ToArray();
                CollectionAssert.AreEqual(result, correctResult);
            }
        }
    }
}