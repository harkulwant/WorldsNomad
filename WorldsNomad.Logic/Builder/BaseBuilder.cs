using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldsNomad.Model.Response;

namespace WorldsNomad.Logic.Builder
{
    public abstract class BaseBuilder<TResponse>
        where TResponse : Response, new()
    {
        public int UserInput { get; set; }
        public TResponse Response { get; set; }

        public BaseBuilder(int userInput)
        {
            UserInput = userInput;
            Response = new TResponse();
        }

        public abstract TResponse Build();
    }
}
