using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialisation_inheritance
{
    class Program
    {
        private static Order CreateOrder()
        {
            Product p1 = new Product
            {
                ID = 1,
                Description = "p2",
                Price = 9
            };
            Product p2 = new Product
            {
                ID = 2,
                Description = "p3",
                Price = 6
            };
            Order order = new VIPOrder
            {
                ID = 4,
                Description = "Order for John Doe. Use the nice giftwrap",
                OrderLines = new List<OrderLine> {
                    new OrderLine { ID = 5, Amount = 1, Product = p1},
                    new OrderLine { ID = 6 ,Amount = 10, Product = p2}
                }
            };
            return order;
        }

        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Order), new Type[] { typeof(VIPOrder) });

            string xml;
            using (StringWriter stringWriter = new StringWriter())
            {
                Order order = CreateOrder();
                serializer.Serialize(stringWriter, order);
                xml = stringWriter.ToString();
            }
            using (StringReader stringReader = new StringReader(xml))
            {
                Order o = (Order)serializer.Deserialize(stringReader); // Use the order
            }
        }
    }
}
