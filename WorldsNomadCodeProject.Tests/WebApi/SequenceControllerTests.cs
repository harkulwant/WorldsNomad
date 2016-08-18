using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldsNomad.Logic.Processor;
using WorldsNomad.Model.Response;
using WorldsNomadApi.Controllers.v1;
using System.Web.Http;
using System.Web.Http.Results;

namespace WorldsNomadCodeProject.WebApi
{
    [TestClass]
    public class SequenceControllerTests
    {
        protected SequenceController Controller { get; set; }
        protected int UserInput { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            UserInput = 50;

            // setup sequence generator
            var sequenceGenerator = MockRepository.GenerateStub<ISequenceGenerator>();
            sequenceGenerator.Stub(x => x.GetNumberSequence(UserInput)).Return(GenerateMockStubResponse<NumberSequence>());
            sequenceGenerator.Stub(x => x.GetOddSequence(UserInput)).Return(GenerateMockStubResponse<OddSequence>());
            sequenceGenerator.Stub(x => x.GetEvenSequence(UserInput)).Return(GenerateMockStubResponse<EvenSequence>());
            sequenceGenerator.Stub(x => x.GetSpeicalSequence(UserInput)).Return(GenerateMockStubResponse<SpecialSequence>());
            sequenceGenerator.Stub(x => x.GetFibonacciSequence(UserInput)).Return(GenerateMockStubResponse<FibonacciSequence>());

            Controller = new SequenceController(sequenceGenerator);
        }


        [TestMethod]
        public async Task GetAllSequences_ShouldReturnArrayOfResponses()
        {
            //ACT
            var result = await Controller.GetAllSequences(UserInput) as OkNegotiatedContentResult<Response[]>;

            //ASSERT
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.Length == 5); //5 types of sequences requested
        }

        [TestMethod]
        public async Task GetNumberSequence()
        {
            //ACT
            var result = await Controller.GetNumberSequence(UserInput) as OkNegotiatedContentResult<Response>;

            //ASSERT
            Assert.IsNotNull(result);
            Assert.IsTrue(UserInput == result.Content.Sequence.Length);
        }

        [TestMethod]
        public async Task GetOddNumberSequence()
        {
            //ACT
            var result = await Controller.GetOddNumberSequence(UserInput) as OkNegotiatedContentResult<Response>;

            //ASSERT
            Assert.IsNotNull(result);
            Assert.IsTrue(!result.Content.Sequence.Any(x => Convert.ToInt32(x) % 2 == 0));
        }

        [TestMethod]
        public async Task GetEvenNumberSequence()
        {
            //ACT
            var result = await Controller.GetEvenNumberSequence(UserInput) as OkNegotiatedContentResult<Response>;

            //ASSERT
            Assert.IsNotNull(result);
            Assert.IsTrue(!result.Content.Sequence.Any(x => Convert.ToInt32(x) % 2 == 1));
        }

        [TestMethod]
        public async Task GetSpecialNumberSequence()
        {
            //ACT
            var result = await Controller.GetSpecialNumberSequence(UserInput) as OkNegotiatedContentResult<Response>;

            //ASSERT
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task GetFibonacciNumberSequence()
        {
            //ACT
            var result = await Controller.GetFibonacciNumberSequence(UserInput) as OkNegotiatedContentResult<Response>;
            
            //ASSERT
            Assert.IsNotNull(result);
        }

        #region Private methods

        public Task<Response> GenerateMockStubResponse<T>() where T : Response
        {
            var type = typeof(T);

            if (type == typeof(OddSequence))
            {
                return Task.Run(() => new NumberSequence() { Type = "Odd sequence", Sequence = Enumerable.Range(1, UserInput).Where(o => o % 2 == 1).Select(x => x.ToString()).ToArray() } as Response);
            }

            if (type == typeof(EvenSequence))
            {
                return Task.Run(() => new NumberSequence() { Type = "Even sequence", Sequence = Enumerable.Range(1, UserInput).Where(o => o % 2 == 0).Select(x => x.ToString()).ToArray() } as Response);
            }

            if (type == typeof(SpecialSequence))
            {
                return Task.Run(() => new NumberSequence() { Type = "Special sequence", Sequence = Enumerable.Range(1, UserInput).Select(x => { if (x % 3 == 0 && x % 5 == 0) return "Z"; if (x % 3 == 0) return "C"; if (x % 5 == 0) return "E"; return x.ToString(); }).ToArray() } as Response);
            }

            if (type == typeof(FibonacciSequence))
            {
                Task.Run(() =>
                {
                    var response = new NumberSequence() { Type = "Fibonacci sequence" };
                    Func<int, int> fibonacci = null;
                    fibonacci = n => n > 1 ? fibonacci(n - 1) + fibonacci(n - 2) : n;

                    var range = Enumerable.Range(1, UserInput);

                    var result = new List<int>();
                    foreach (var i in range)
                    {
                        var fib = fibonacci(i);

                        if (fib > UserInput)
                            break;

                        result.Add(fib);
                    }

                    response.Sequence = result.Select(x => x.ToString()).ToArray();

                    return response as Response;
                });
            }

            return Task.Run(() => new NumberSequence() { Type = "Number sequence", Sequence = Enumerable.Range(1, UserInput).Select(x => x.ToString()).ToArray() } as Response);
        }

        #endregion
    }
}
