using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WorldsNomad.Model.Response
{
    [DataContract]
    public class FibonacciSequence : Response
    {
        const string ResponseType = "Fibonacci numbers (S3.1.5)";

        public FibonacciSequence() : base(ResponseType)
        {
        }

        [DataMember]
        public override string[] Sequence
        {
            get; set;
        }

    }
}
