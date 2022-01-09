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
            xmlRepresentation = @"G:\csharp\farajTrainingFinal\05-LinqToXml\LinqToXml.Test\Resources\CreateHierarchyResultFile.xml";

            XDocument xdoc = XDocument.Load(xmlRepresentation);

            //xdoc.Descendants("Data").Elements("Category").Remove();
            //xdoc.Element("Root").Element("TaxRate").Remove();
            //xdoc.Element("Root").AddFirst(new XElement("Group", new XAttribute("ID", "A")));
            //xdoc.Descendants("Root").Elements("Data").Where(x => x.Element("Quantity").Value == "1").FirstOrDefault().AddBeforeSelf(new XElement("Group", new XAttribute("ID", "B")));


            //xdoc.Save(xmlRepresentation);



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
            IEnumerable<string> purchaseOrders =
                from el in root.Elements(aw + "PurchaseOrder")
                where
                    (from add in el.Elements(aw + "Address")
                     where
                         (string)add.Attribute(aw + "Type") == "Shipping" &&
                         (string)add.Element(aw + "State") == "NY"
                     select add)
                    .Any()
                select el.Attribute(aw + "PurchaseOrderNumber").Value;


            return String.Join(",", purchaseOrders);
            }

            /// <summary>
            /// Reads csv representation and creates appropriate xml representation
            /// </summary>
            /// <param name="customers">Csv customers representation (refer to XmlFromCsvSourceFile.csv in Resources)</param>
            /// <returns>Xml customers representation (refer to XmlFromCsvResultFile.xml in Resources)</returns>
            public static string ReadCustomersFromCsv(string customers)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Gets recursive concatenation of elements
            /// </summary>
            /// <param name="xmlRepresentation">Xml representation of document with Sentence, Word and Punctuation elements. (refer to ConcatenationStringSource.xml in Resources)</param>
            /// <returns>Concatenation of all this element values.</returns>
            public static string GetConcatenationString(string xmlRepresentation)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Replaces all "customer" elements with "contact" elements with the same childs
            /// </summary>
            /// <param name="xmlRepresentation">Xml representation with customers (refer to ReplaceCustomersWithContactsSource.xml in Resources)</param>
            /// <returns>Xml representation with contacts (refer to ReplaceCustomersWithContactsResult.xml in Resources)</returns>
            public static string ReplaceAllCustomersWithContacts(string xmlRepresentation)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Finds all ids for channels with 2 or more subscribers and mark the "DELETE" comment
            /// </summary>
            /// <param name="xmlRepresentation">Xml representation with channels (refer to FindAllChannelsIdsSource.xml in Resources)</param>
            /// <returns>Sequence of channels ids</returns>
            public static IEnumerable<int> FindChannelsIds(string xmlRepresentation)
            {
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
            XDocument xdoc = new XDocument( new XElement(xmlRepresentation));


            //xdoc.Save(@"G:\", SaveOptions.DisableFormatting);


            return xdoc.ToString();

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