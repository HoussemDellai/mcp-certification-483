using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Serializer_DataContract
{
    [DataContract]
    class MainVO
    {
        private List<IDemo> _listOfAll = new List<IDemo>();

        public List<IDemo> ListOfAll
        {
            get {
                //de-serialisation doesn't call constructor or initialize Vars, so we need to check for null
                if(_listOfAll == null)
                {
                    //init
                    _listOfAll = new List<IDemo>();
                }
                return _listOfAll;
            }
            set {
                _listOfAll = value;
            }
        }

        [DataMember]
        public List<FirstDemoImpl> FirstDemoImplLst
        {
            get
            {
                return ListOfAll
                    .Where(i => i is FirstDemoImpl)
                    .Select(i => i as FirstDemoImpl).ToList();
            }
            private set
            {
                // only used by deserializer
                ListOfAll.AddRange(value);
            }
        }

    }
}
