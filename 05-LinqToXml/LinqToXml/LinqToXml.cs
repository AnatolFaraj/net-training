using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace LinqToXml
{
    public static class LinqToXml
    {
        /// <summary>
        /// Creates hierarchical data grouped by category
        /// </summary>
        /// <param name="xmlRepresentation">Xml representation (refer to CreateHierarchySourceFile.xml in Resources)</param>
        /// <returns>Xml representation (refer to CreateHierarchyResultFile.xml in Resources)</returns>
        public static string CreateHierarchy(string xmlRepresentation)
        {
            xmlRepresentation = @"G:\csharp\farajTrainingFinal\05-LinqToXml\LinqToXml.Test\Resources\CreateHierarchySourceFile.xml";

            XDocument xdoc = XDocument.Load(xmlRepresentation);

            xdoc.Elements().Remove();

            xdoc.Add(
                new XElement("Root",
                            new XElement("Group", new XAttribute("ID", "A"),
                                        new XElement("Data",
                                             new XElement("Quantity", "3"),
                                             new XElement("Price", "24.50" )),
                                        new XElement("Data",
                                             new XElement("Quantity", "5"),
                                             new XElement("Price", "4.95")),
                                        new XElement("Data",
                                             new XElement("Quantity", "3"),
                                             new XElement("Price", "66.00")),
                                        new XElement("Data",
                                             new XElement("Quantity", "15"),
                                             new XElement("Price", "29.00"))),
                            new XElement("Group", new XAttribute("ID", "B"),
                                            new XElement("Data",
                                             new XElement("Quantity", "1"),
                                             new XElement("Price", "89.99")),
                                        new XElement("Data",
                                             new XElement("Quantity", "10"),
                                             new XElement("Price", ".99")),
                                        new XElement("Data",
                                             new XElement("Quantity", "8"),
                                             new XElement("Price", "6.99"))
                                    )));



            return xdoc.ToString();
        }



            /// <summary>
            /// Get list of orders numbers (where shipping state is NY) from xml representation
            /// </summary>
            /// <param name="xmlRepresentation">Orders xml representation (refer to PurchaseOrdersSourceFile.xml in Resources)</param>
            /// <returns>Concatenated orders numbers</returns>
            /// <example>
            /// 99301,99189,99110
            /// </example>
            public static string GetPurchaseOrders(string xmlRepresentation)
            {
                xmlRepresentation = @"G:\csharp\farajTrainingFinal\05-LinqToXml\LinqToXml.Test\Resources\PurchaseOrdersSourceFile.xml";
                XNamespace aw = "http://www.adventure-works.com";

            XElement root = XElement.Load(xmlRepresentation);
            
            var a = root.Elements(aw + "PurchaseOrder").Select(x => x.Element(aw + "Address").Element(aw + "State"))
                                                       .Where(x => x.Parent.Attribute(aw + "Type").Value == "Shipping" && x.Value == "NY")
                                                       .Select(x => x.Parent.Parent.Attribute(aw + "PurchaseOrderNumber").Value);


            return String.Join(",", a);
            
            }

            /// <summary>
            /// Reads csv representation and creates appropriate xml representation
            /// </summary>
            /// <param name="customers">Csv customers representation (refer to XmlFromCsvSourceFile.csv in Resources)</param>
            /// <returns>Xml customers representation (refer to XmlFromCsvResultFile.xml in Resources)</returns>
            public static string ReadCustomersFromCsv(string customers)
            {
                customers = @"G:\csharp\farajTrainingFinal\05-LinqToXml\LinqToXml.Test\Resources\XmlFromCsvSourceFile.csv";
            var lines = File.ReadAllLines(customers);

            var xml = new XElement("Root",
                lines.Select(line => new XElement("Customer", new XAttribute("CustomerID", line.Split(',').First()),
                                           new XElement("CompanyName", line.Split(',').ElementAt(1)),
                                           new XElement("ContactName", line.Split(',').ElementAt(2)),
                                           new XElement("ContactTitle", line.Split(',').ElementAt(3)),
                                           new XElement("Phone", line.Split(',').ElementAt(4)),
                                           new XElement("FullAddress",
                                            new XElement("Address", line.Split(',').ElementAt(5)),
                                            new XElement("City", line.Split(',').ElementAt(6)),
                                            new XElement("Region", line.Split(',').ElementAt(7)),
                                            new XElement("PostalCode", line.Split(',').ElementAt(8)),
                                            new XElement("Country", line.Split(',').ElementAt(9))))));

            return xml.ToString();
            }

            /// <summary>
            /// Gets recursive concatenation of elements
            /// </summary>
            /// <param name="xmlRepresentation">Xml representation of document with Sentence, Word and Punctuation elements. (refer to ConcatenationStringSource.xml in Resources)</param>
            /// <returns>Concatenation of all this element values.</returns>
            public static string GetConcatenationString(string xmlRepresentation)
            {
                xmlRepresentation = @"G:\csharp\farajTrainingFinal\05-LinqToXml\LinqToXml.Test\Resources\ConcatenationStringSource.xml";
                var xdoc = XDocument.Load(xmlRepresentation);
                var returnString = xdoc.Descendants("Sentence").Select(x => x.Value).ToList();
            
                return String.Join("", returnString);
                
            }

            /// <summary>
            /// Replaces all "customer" elements with "contact" elements with the same childs
            /// </summary>
            /// <param name="xmlRepresentation">Xml representation with customers (refer to ReplaceCustomersWithContactsSource.xml in Resources)</param>
            /// <returns>Xml representation with contacts (refer to ReplaceCustomersWithContactsResult.xml in Resources)</returns>
            public static string ReplaceAllCustomersWithContacts(string xmlRepresentation)
            {
            xmlRepresentation = @"G:\csharp\farajTrainingFinal\05-LinqToXml\LinqToXml.Test\Resources\ReplaceCustomersWithContactsSource.xml";

            //var xdoc = XDocument.Load(xmlRepresentation).Descendants("Document")
            //                                            //.Elements("customer")
            //                                            .Where(x => x.Element("customer"))

            //                                            //.Select(x => x.Element("customer").Name == "contact");


            //return xdoc.ToString();
            throw new NotImplementedException();

            }

            /// <summary>
            /// Finds all ids for channels with 2 or more subscribers and mark the "DELETE" comment
            /// </summary>
            /// <param name="xmlRepresentation">Xml representation with channels (refer to FindAllChannelsIdsSource.xml in Resources)</param>
            /// <returns>Sequence of channels ids</returns>
            public static IEnumerable<int> FindChannelsIds(string xmlRepresentation)
            {
            //var comment = new XComment("DELETE");
            //xmlRepresentation = @"G:\csharp\farajTrainingFinal\05-LinqToXml\LinqToXml.Test\Resources\FindAllChannelsIdsSource.xml";
            //var xdoc = XDocument.Load(xmlRepresentation).Descendants("service")
            //                                            .Elements("channel")
            //                                            .Where(x => x.Elements("subsdcriber").Count() >= 2 && x.Elements("subscriber").)
            //                                            ;


            //return xdoc;
            throw new NotImplementedException();
            }

            /// <summary>
            /// Sort customers in docement by Country and City
            /// </summary>
            /// <param name="xmlRepresentation">Customers xml representation (refer to GeneralCustomersSourceFile.xml in Resources)</param>
            /// <returns>Sorted customers representation (refer to GeneralCustomersResultFile.xml in Resources)</returns>
            public static string SortCustomers(string xmlRepresentation)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Gets XElement flatten string representation to save memory
            /// </summary>
            /// <param name="xmlRepresentation">XElement object</param>
            /// <returns>Flatten string representation</returns>
            /// <example>
            ///     <root><element>something</element></root>
            /// </example>
            public static string GetFlattenString(XElement xmlRepresentation)
            {
            //XDocument xdoc = new XDocument( new XElement(xmlRepresentation));


            ////xdoc.Save(@"G:\", SaveOptions.DisableFormatting);


            //return xdoc.ToString();
            throw new NotImplementedException();
            }

            /// <summary>
            /// Gets total value of orders by calculating products value
            /// </summary>
            /// <param name="xmlRepresentation">Orders and products xml representation (refer to GeneralOrdersFileSource.xml in Resources)</param>
            /// <returns>Total purchase value</returns>
            public static int GetOrdersValue(string xmlRepresentation)
            {
            //    XElement root = XElement.Load(xmlRepresentation);
            //var values = root.Elements("products")
            //                      .Select(x => x.Attribute("Value").Value);
            //var prodID = root.Elements("Order")
            //                 .Select(x => x.Element("product").Value);

            //    return 
            throw new NotImplementedException();
            }
       
    }
}