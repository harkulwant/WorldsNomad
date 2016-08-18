using System.Linq;
using WorldsNomad.Model.Response;

namespace WorldsNomad.Logic.Builder
{
    public class NumberSequenceBuilder : BaseBuilder<NumberSequence>
    {
        public NumberSequenceBuilder(int userInput) : base(userInput)
        {
        }

        public override NumberSequence Build()
        {
            Response.Sequence = Enumerable.Range(1, UserInput).Select(x => x.ToString()).ToArray();
            return Response;
        }
    }
}
