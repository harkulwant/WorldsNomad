using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WorldsNomad.Model.Response
{
    /// <summary>
    /// Serialization to service Accept header of application/xml
    /// </summary>
    [DataContract]
    [KnownType("GetKnownTypes")]
    public abstract class Response
    {
        [DataMember]
        public string Type { get; set; }

        public Response(string type)
        {
            Type = type;
        }

        [DataMember]
        public abstract string[] Sequence { get; set; }

        [DataMember]
        public string SequenceToString { get { return string.Join(", ", Sequence); } }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Type, SequenceToString);
        }

        static Type[] GetKnownTypes()
        {
            return new Type[]
            {
                typeof(NumberSequence),
                typeof(OddSequence),
                typeof(EvenSequence),
                typeof(SpecialSequence),
                typeof(FibonacciSequence)
            };
        }
    }

}
