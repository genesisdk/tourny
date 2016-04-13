using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace tourny
{
    class Jsonweb
    {
     //       NetworkCredential myCredentials = new NetworkCredential("genesisdk", "VguCV2pMBFhr7qBQZQ0UgEac7fEGzr3ELV7PqycE");

     //public string GET(string url)
     //   {
            
     //       HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
     //       try
     //       {
     //           request.Credentials = myCredentials.GetCredential(new Uri(url), "");
     //           WebResponse response = request.GetResponse();
     //           using (Stream responseStream = response.GetResponseStream())
     //           {
     //               StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
     //               return reader.ReadToEnd();
     //           }
     //       }
     //       catch (WebException ex)
     //       {
     //           WebResponse errorResponse = ex.Response;
     //           using (Stream responseStream = errorResponse.GetResponseStream())
     //           {
     //               StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
     //               String errorText = reader.ReadToEnd();
     //               // log errorText
     //           }
     //           throw;
     //       }
     //   }


     //  public void POST(string url, string jsonContent)
     //   {
     //       HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
     //       request.Credentials = myCredentials.GetCredential(new Uri(url), "");
     //       request.Method = "POST";
            

     //       System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
     //       Byte[] byteArray = encoding.GetBytes(jsonContent);

     //       request.ContentLength = byteArray.Length;
     //       request.ContentType = @"application/json";

     //       using (Stream dataStream = request.GetRequestStream())
     //       {
     //           dataStream.Write(byteArray, 0, byteArray.Length);
     //       }
     //       long length = 0;
     //       try
     //       {
     //           using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
     //           {
     //               length = response.ContentLength;
     //           }
     //       }
     //       catch (WebException ex)
     //       {
     //           // Log exception and throw as for GET example above
     //           WebResponse errorResponse = ex.Response;
     //           using (Stream responseStream = errorResponse.GetResponseStream())
     //           {
     //               StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
     //               String errorText = reader.ReadToEnd();
     //               Console.WriteLine(errorText);
     //           }
     //           if (ex.Status == WebExceptionStatus.ProtocolError)
     //           {
     //               HttpWebResponse response = ex.Response as HttpWebResponse;
     //               if (response != null)
     //               {
     //                   // Process response
     //               }
     //           }
     //           throw;
     //       }
     //   }


     //   public void Newpost(string url, string json)
     //   {
     //       string result = "";
     //       using (var client = new WebClient())
     //       {
     //           //request.Credentials = myCredentials.GetCredential(new Uri(url), "");
     //           client.Credentials= myCredentials.GetCredential(new Uri(url), "");
     //           client.Headers[HttpRequestHeader.ContentType] = "application/json";
     //           client.Headers.Add("Accept-Language", " en-US");
     //           //client.Headers.Add("Accept", " text/html, application/xhtml+xml, */*");
     //           client.Headers.Add("User-Agent", "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)");
     //           client.Headers["Content-Type"] = "application/json;charset=UTF-8";
     //           result = client.UploadString(url, "POST", json);
     //       }
     //       Console.WriteLine(result);

     //   }

        public  void test(string url)
        { HttpClientHandler handler = new HttpClientHandler();
                handler.Credentials = new NetworkCredential("genesisdk", "VguCV2pMBFhr7qBQZQ0UgEac7fEGzr3ELV7PqycE");
              
            using (var client = new HttpClient(handler))
            {
               
                var request = new CreateAppRequest()
                {
                   name = "genesisdk"
                   
                    
                };

                var response = client.PostAsync(url,
                    new StringContent(JsonConvert.SerializeObject(request).ToString(),
                        Encoding.UTF8, "application/json"))
                        .Result;

                if (response.IsSuccessStatusCode)
                {
                    dynamic content = JsonConvert.DeserializeObject(
                        response.Content.ReadAsStringAsync()
                        .Result);

                    // Access variables from the returned JSON object
                    var appHref = content.links.applications.href;
                }
              
                Console.WriteLine(response);
            }
        }
    }
}
