using System;
using System.Runtime.Serialization;

namespace Serializer_DataContract
{
    [DataContract]
    abstract class AbstractDemoBase : IDemo
    {
        private string _nameImplementedInAbstractClass;

        [DataMember] // this property is missing, if we only use the DataMemberAttribute in FirstDemoImpl.
        public abstract int ValueImplementedInImplementation { get; set; }

        [DataMember]
        public string NameImplementedInAbstractClass
        {
            get
            {
                return _nameImplementedInAbstractClass;
            }
            set
            {
                _nameImplementedInAbstractClass = value;
            }
        }

        [DataMember]
        public int ValueDefinedInAbstractBase { get; set; }
    }
}