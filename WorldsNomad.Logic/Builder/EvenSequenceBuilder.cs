using System.Linq;
using WorldsNomad.Model.Response;

namespace WorldsNomad.Logic.Builder
{
    public class EvenSequenceBuilder : BaseBuilder<EvenSequence>
    {
        public EvenSequenceBuilder(int userInput) : base(userInput)
        {
        }

        public override EvenSequence Build()
        {
            Response.Sequence = Enumerable.Range(1, UserInput).Where(e => e % 2 == 0).Select(x => x.ToString()).ToArray();
            return Response;
        }
    }
}
