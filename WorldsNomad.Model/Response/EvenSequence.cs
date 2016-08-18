using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WorldsNomad.Model.Response
{
    [DataContract]
    public class EvenSequence : Response
    {
        const string ResponseType = "Even numbers (S3.1.3)";

        public EvenSequence() : base(ResponseType)
        {
        }

        [DataMember]
        public override string[] Sequence
        {
            get; set;
        }

    }
}
