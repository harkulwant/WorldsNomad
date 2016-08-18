using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WorldsNomad.Model.Response
{
    [DataContract]
    public class OddSequence : Response
    {
        const string ResponseType = "Odd numbers (S3.1.2)";

        public OddSequence() : base(ResponseType)
        {
        }

        [DataMember]
        public override string[] Sequence
        {
            get; set;
        }
    }
}
