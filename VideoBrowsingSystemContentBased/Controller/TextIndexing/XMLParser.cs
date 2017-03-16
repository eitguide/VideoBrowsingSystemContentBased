using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using VideoBrowsingSystemContentBased.Controller;
using VideoBrowsingSystemContentBased.Model;

namespace VideoBrowsingSystemContentBased.TextIndexing
{
    public class XMLParser
    {

        /// <summary>
        /// Processing Data Xml
        /// </summary>
        /// <param name="xmlFolderPath"></param>
        /// <returns>Key: File Path, value: Text plotting</returns>
        public static List<TextSpot> ProcessingXmlData(String xmlFolderPath)
        {
            FileInfo[] fileInfos = FileManager.GetInstance().GetAllFileInFolder(xmlFolderPath);

            List<TextSpot> textPlt = new List<TextSpot>();

            foreach (var item in fileInfos)
            {
                //FullName: get Absulute Path
                //Name: Get Name of files
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(item.FullName);

                XmlNodeList xmlNodeList = xmlDocument.GetElementsByTagName("img");

                foreach (XmlNode node in xmlNodeList)
                {
                    String fileName = node.Attributes[0].Value;
                    StringBuilder builder = new StringBuilder();

                    XmlNodeList txtNodes = node.SelectNodes(".//txt");
                    if (txtNodes.Count == 0)
                        break;

                    foreach (XmlNode n in txtNodes)
                    {
                        String text = n.Attributes["lexRecog"].Value;
                        builder.Append(text + " ");
                    }

                    textPlt.Add(new TextSpot(fileName, builder.ToString()));
                }
            }

            return textPlt;
        }
    }
}
