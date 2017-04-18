using System;
using System.IO;
using System.Xml;

namespace ConsumingXML
{
    class Program
    {

        static string xml = @"<?xml version=""1.0"" encoding =""utf-8"" ?>
                           <people>
                              <person firstname=""John"" lastname =""Doe"">
                                 <contactdetails>
                                    <emailaddress> john@unknown.com </emailaddress>
                                 </contactdetails>
                              </person>
                              <person firstname=""Jane"" lastname=""Doe"">
                                 <contactdetails>
                                    <emailaddress> jane@unknown.com </emailaddress>
                                    <phonenumber> 001122334455 </phonenumber>
                                 </contactdetails>
                              </person>
                           </people>";

        static void Main(string[] args)
        {

            ReadingXML();

            WritingXML();

            UsingXmlDocument();

            Console.ReadLine();
        }

        private static void UsingXmlDocument()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlNodeList nodes = doc.GetElementsByTagName("person");
            // Output the names of the people in the document
            foreach (XmlNode node in nodes)
            {
                string firstName = node.Attributes["firstname"].Value;
                string lastName = node.Attributes["lastname"].Value;
                Console.WriteLine("name: {0} {1}", firstName, lastName);
            }

            // Start creating a new node
            XmlNode newNode = doc.CreateNode(XmlNodeType.Element, "person", "");
            XmlAttribute firstNameAttribute = doc.CreateAttribute("firstname");
            firstNameAttribute.Value = "Foo";
            XmlAttribute lastNameAttribute = doc.CreateAttribute("lastname");
            lastNameAttribute.Value = "Bar";
            newNode.Attributes.Append(firstNameAttribute);
            newNode.Attributes.Append(lastNameAttribute);
            doc.DocumentElement.AppendChild(newNode);
            Console.WriteLine("Modified xml...");
            doc.Save(Console.Out);
            //Displays:
            //Name: john doe
            //Name: jane doe
            //Modified xml...
            //<?xml version=”1.0” encoding=”ibm850”?>
            //<people>
            // <person firstname=”john” lastname=”doe”>
            // <contactdetails>
            // <emailaddress>john@unknown.com</emailaddress>
            // </contactdetails>
            // </person>
            // <person firstname=”jane” lastname=”doe”>
            // <contactdetails>
            // <emailaddress>jane@unknown.com</emailaddress>
            // <phonenumber>001122334455</phonenumber>
            // </contactdetails>
            // </person>
            // <person firstname=”Foo” lastname=”Bar” />
            //</people>
        }

        private static void WritingXML()
        {
            StringWriter stream = new StringWriter();
            using (XmlWriter writer = XmlWriter.Create(stream,
            new XmlWriterSettings()
            {
                Indent = true
            }))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("People");
                writer.WriteStartElement("Person");
                writer.WriteAttributeString("firstName", "John");
                writer.WriteAttributeString("lastName", "Doe");
                writer.WriteStartElement("ContactDetails");
                writer.WriteElementString("EmailAddress", "john@unknown.com");
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Flush();
            }
            Console.WriteLine(stream.ToString());

        }

        private static void ReadingXML()
        {


            using (StringReader stringReader = new StringReader(xml))
            {
                using (XmlReader xmlReader = XmlReader.Create(stringReader,
                    new XmlReaderSettings()
                    {
                        IgnoreWhitespace = true
                    }))
                {
                    xmlReader.MoveToContent();
                    xmlReader.ReadStartElement("people");
                    string firstName = xmlReader.GetAttribute("firstname");
                    string lastName = xmlReader.GetAttribute("lastname");
                    Console.WriteLine("person: {0} {1}", firstName, lastName);
                    xmlReader.ReadStartElement("person");
                    Console.WriteLine("contactdetails");
                    xmlReader.ReadStartElement("contactdetails");
                    string emailAddress = xmlReader.ReadString();
                    Console.WriteLine("Email address: {0}", emailAddress);
                }
            }
        }
    }
}
