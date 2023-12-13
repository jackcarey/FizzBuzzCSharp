using FizzBuzzCSharp;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace FizzBuzzTests
{
    [TestClass]
    public class ArgumentTests
    {
        private void CheckResults(ref Dictionary<int, string> multiples, ref Dictionary<int, string> results)
        {
            foreach (var result in results)
            {
                string res = FizzBuzz.MultipleString(result.Key, ref multiples);
                Assert.AreEqual(result.Value, res);
            }
        }
        [TestMethod]
        public void TestThreeFive()
        {
            Dictionary<int, string> multiples = new Dictionary<int, string> { { 3, "Fizz" }, { 5, "Buzz" } };
            Dictionary<int, string> results = new Dictionary<int, string> {
                {3, "Fizz" },
                {5,"Buzz" },
                {15,"FizzBuzz" },
            };
            CheckResults(ref multiples, ref results);
        }
        [TestMethod]
        public void SpotCheck()
        {
            Dictionary<int, string> multiples = new Dictionary<int, string> { { 3, "Fizz" }, { 5, "Buzz" } };
            Dictionary<int, string> results = new Dictionary<int, string> {
                {15,"FizzBuzz" },
                {22,"22" },
                {45,"FizzBuzz" },
                {89,"89" },
                {99,"Fizz" },
                {100,"Buzz" }
            };
            CheckResults(ref multiples, ref results);
        }
        [TestMethod]
        public void NegativeNumbers()
        {
            Dictionary<int, string> multiples = new Dictionary<int, string> { { 3, "Fizz" }, { 5, "Buzz" } };
            Dictionary<int, string> results = new Dictionary<int, string> {
                {-15,"FizzBuzz" },
                {-22,"-22" },
                {-33,"Fizz" },
                {-98,"-98" },
                {-101,"-101" },
                {-105,"FizzBuzz" }
            };
            CheckResults(ref multiples, ref results);
        }
        [TestMethod]
        public void NonStandardMultiples()
        {
            Dictionary<int, string> multiples = new Dictionary<int, string> { { 3, "Fizz" }, { 5, "Buzz" }, { 7, "Bang" }, { 11, "Whoosh" } };
            Dictionary<int, string> results = new Dictionary<int, string> {
                {3, "Fizz" },
                {5,"Buzz" },
                {7,"Bang" },
                {11,"Whoosh" },
                { 15, "FizzBuzz" },
                {21,"FizzBang" },
                {33,"FizzWhoosh" },
                {35,"BuzzBang" },
                {55,"BuzzWhoosh" },
                {77,"BangWhoosh" },
                {99,"FizzWhoosh" }
            };
            CheckResults(ref multiples, ref results);
        }
    }
}