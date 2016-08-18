using System.Linq;
using WorldsNomad.Model.Response;

namespace WorldsNomad.Logic.Builder
{
    public class SpecialSequenceBuilder : BaseBuilder<SpecialSequence>
    {
        public SpecialSequenceBuilder(int userInput) : base(userInput)
        {
        }

        public override SpecialSequence Build()
        {
            Response.Sequence = Enumerable.Range(1, UserInput)
                .Select(x => 
                    {
                        if (x % 3 == 0 && x % 5 == 0)
                            return "Z";

                        if (x % 3 == 0)
                            return "C";

                        if (x % 5 == 0)
                            return "E";

                        return x.ToString();
                    }).ToArray();
            return Response;
        }
    }
}
