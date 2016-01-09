using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace tourny
{
    class Program
    {


        static void Main(string[] args)
        {

            //string url = "https://genesisdk:VguCV2pMBFhr7qBQZQ0UgEac7fEGzr3ELV7PqycE@api.challonge.com/v1/tournaments.xml";
            string url = "https://api.challonge.com/v1/tournaments.xml";
           
           

       

            using (WebClient wc = new WebClient())
            {
                wc.Credentials = new NetworkCredential("genesisdk", "VguCV2pMBFhr7qBQZQ0UgEac7fEGzr3ELV7PqycE");
                string xml = wc.DownloadString(url);

                XmlDocument tournamentsXML = new XmlDocument();
                tournamentsXML.LoadXml(xml);
                Console.Write(xml);
                Console.ReadKey();
            }

        
    }

    }
}
