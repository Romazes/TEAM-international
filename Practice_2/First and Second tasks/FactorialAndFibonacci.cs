using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice_2
{
    class FactorialAndFibonacci
    {
        public delegate void OutputHandler(string message);
        public event OutputHandler Notify;

        /// <summary>
        /// Calculate n's number Fibonacci
        /// </summary>
        /// <param name="number">The number which need to calculate</param>
        /// <returns>It can return all numbers from sequence or only looked for numberk</returns>
        public IEnumerable<int> Fibonacci(int number)
        {
            if (number < 0)
                throw new Exception($"Fibonacci doesn't take negative number");
            List<int> fibNumbers = new List<int>();
            Enumerable.Range(0, number).ToList()
                .ForEach(f => fibNumbers.Add(f <= 1 ? 1 : fibNumbers[f-2] + fibNumbers[f-1]));
            Notify?.Invoke($"Фибоначчи числа {number} = {fibNumbers.Last()}");
            return fibNumbers;
        }


        /// <summary>
        /// Factorial of a number calculator
        /// </summary>
        /// <param name="number">The number which need to calculate</param>
        /// <returns>Factorial form number</returns>
        public void Factorial(int number)
        {
            if (number < 0)
                throw new Exception($"Factorial doesn't take negative number");
            var temp = number == 0 ? 1 : Enumerable.Range(1, number).Aggregate((i, j) => i * j);
            Notify?.Invoke($"Факториал от числа {number} = {temp}");
        }
    }
}
