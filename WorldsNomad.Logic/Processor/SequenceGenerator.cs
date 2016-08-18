using System.Threading.Tasks;
using WorldsNomad.Logic.Builder;
using WorldsNomad.Model.Response;

namespace WorldsNomad.Logic.Processor
{
    public interface ISequenceGenerator
    {
        Task<Response> GetNumberSequence(int userInput);
        Task<Response>  GetOddSequence(int userInput);
        Task<Response> GetEvenSequence(int userInput);
        Task<Response> GetSpeicalSequence(int userInput);
        Task<Response> GetFibonacciSequence(int userInput);
    }

    public class SequenceGenerator : ISequenceGenerator
    {

        public async Task<Response> GetNumberSequence(int userInput)
        {
            return await Task.Run(() => new NumberSequenceBuilder(userInput).Build());
        }

        public async Task<Response> GetEvenSequence(int userInput)
        {
            return await Task.Run(() => new EvenSequenceBuilder(userInput).Build());
        }

        public async Task<Response> GetFibonacciSequence(int userInput)
        {
            return await Task.Run(() => new FibonacciSequenceBuilder(userInput).Build());
        }

        public async Task<Response> GetSpeicalSequence(int userInput)
        {
            return await Task.Run(() => new SpecialSequenceBuilder(userInput).Build());
        }

        public async Task<Response> GetOddSequence(int userInput)
        {
            return await Task.Run(() => new OddSequenceBuilder(userInput).Build());
        }
    }
}
