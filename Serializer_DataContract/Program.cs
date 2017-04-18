using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Serializer_DataContract
{
    class Program
    {
        static void Main(string[] args)
        {
            // i had an issue serializing an instance of an class with a list of interfaces.
            // the classes implementing an abstract base class implementing this interface aren't that easy to manage

            MainVO mainVOOrig = new MainVO();
            mainVOOrig.ListOfAll.Add(new FirstDemoImpl()
            {
                NameImplementedInAbstractClass = "FirstDemoImpl",
                ValueDefinedInAbstractBase = 3,
                ValueDefinedInFirstImplementation = 5,
                ValueImplementedInImplementation = 7
            });

            //serialize

            string xml = null;
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(MainVO));
                serializer.WriteObject(ms, mainVOOrig);
                ms.Flush();
                ms.Position = 0;
                StreamReader reader = new StreamReader(ms);
                xml = reader.ReadToEnd();
            }
            
            //deserialize
            MainVO mainVODeserialized = null;
            DataContractSerializer dcs = new DataContractSerializer(typeof(MainVO));
            using (StringReader reader = new StringReader(xml))
            {
                using (XmlReader xmlReader = new XmlTextReader(reader))
                {
                    mainVODeserialized = (MainVO)dcs.ReadObject(xmlReader);
                }
            }

            //check for differences
            Debug.Assert(mainVOOrig.ListOfAll.Count == mainVODeserialized.ListOfAll.Count);
            Debug.Assert(mainVOOrig.FirstDemoImplLst.Count == mainVODeserialized.FirstDemoImplLst.Count);
            var fdOrig = mainVOOrig.FirstDemoImplLst.First();
            var fdDeser = mainVODeserialized.FirstDemoImplLst.First();
            Debug.Assert(fdOrig.NameImplementedInAbstractClass == fdDeser.NameImplementedInAbstractClass);
            Debug.Assert(fdOrig.ValueDefinedInAbstractBase == fdDeser.ValueDefinedInAbstractBase);
            Debug.Assert(fdOrig.ValueDefinedInFirstImplementation == fdDeser.ValueDefinedInFirstImplementation);
            Debug.Assert(fdOrig.ValueImplementedInImplementation == fdDeser.ValueImplementedInImplementation);
        }
    }
}
