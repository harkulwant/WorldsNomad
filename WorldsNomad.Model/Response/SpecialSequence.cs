using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WorldsNomad.Model.Response
{
    [DataContract]
    public class SpecialSequence : Response
    {
        const string ResponseType = "Special sequence (S3.1.4)";

        public SpecialSequence() : base(ResponseType)
        {
        }

        [DataMember]
        public override string[] Sequence
        {
            get; set;
        }

    }
}
