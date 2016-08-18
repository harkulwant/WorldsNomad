using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WorldsNomad.Model.Response
{
    [DataContract]
    public class NumberSequence : Response
    {
        const string ResponseType = "All numbers (S3.1.1)";

        public NumberSequence() : base(ResponseType)
        {
        }

        [DataMember]
        public override string[] Sequence
        {
            get; set;
        }

    }
}
