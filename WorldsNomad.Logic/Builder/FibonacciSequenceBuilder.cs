using System;
using System.Collections.Generic;
using System.Linq;
using WorldsNomad.Model.Response;

namespace WorldsNomad.Logic.Builder
{
    public class FibonacciSequenceBuilder : BaseBuilder<FibonacciSequence>
    {
        public FibonacciSequenceBuilder(int userInput) : base(userInput)
        {
        }

        public override FibonacciSequence Build()
        {
            Func<int, int> fibonacci = null;
            fibonacci = n => n > 1 ? fibonacci(n-1) + fibonacci(n - 2) : n;

            var range = Enumerable.Range(1, UserInput);

            var result = new List<int>();
            foreach(var i in range)
            {
                var fib = fibonacci(i);

                if (fib > UserInput)
                    break;

                result.Add(fib);
            }

            // very inefficient
            //Response.Sequence = Enumerable..Range(0, Request.Data).Select(fibonacci).Select(x => x.ToString()).ToArray();

            Response.Sequence = result.Select(x => x.ToString()).ToArray();

            return Response;
        }
    }
}
