using System.Linq;
using WorldsNomad.Model.Response;

namespace WorldsNomad.Logic.Builder
{
    public class OddSequenceBuilder : BaseBuilder<OddSequence>
    {
        public OddSequenceBuilder(int userInput) : base(userInput)
        {
        }

        public override OddSequence Build()
        {
            Response.Sequence = Enumerable.Range(1, UserInput).Where(o => o%2 == 1).Select(x => x.ToString()).ToArray();
            return Response;
        }
    }
}
