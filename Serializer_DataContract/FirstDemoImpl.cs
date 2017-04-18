using System;
using System.Runtime.Serialization;

namespace Serializer_DataContract
{
    [DataContract]
    internal class FirstDemoImpl : AbstractDemoBase
    {
        private int _valueImplementedInImplementation;

        [DataMember]
        public override int ValueImplementedInImplementation
        {
            get
            {
                return _valueImplementedInImplementation;
            }
            set
            {
                _valueImplementedInImplementation = value;
            }
        }

        [DataMember]
        public int ValueDefinedInFirstImplementation { get; set; }
    }
}