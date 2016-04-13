using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using System.Data;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Linq;

namespace tourny
{
    class Program
    {


        static void Main(string[] args)
        {
            
            Jsonweb web = new Jsonweb();

            //string Json = "https://api.challonge.com/v1/tournaments.json";
            //var STUFF = web.GET(Json);



            string participent = "https://api.challonge.com/v1/tournaments/925711/participants.json";
            string info = " {participant: {participant[name]:genesisdk}}";   // is valid!!!!
            //string  info = "{participant:{ challonge_username: genesisdk}";
            //string info = "participant[name] : azir";
            //string info = "{participant:{participant[name] : azir";
            //var postData = "{\"platform\":\"[1]\", \"msg\":\"Hi from Tali\" ,\"badge\":\"10\" ,\"sound\":\"default\"}";
            web.test(participent);
            Console.ReadLine();
        }

}
}



    

