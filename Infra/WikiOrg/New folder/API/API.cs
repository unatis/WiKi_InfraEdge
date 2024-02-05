using Common;
using Newtonsoft.Json.Linq;
using RestHTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static RestHTTP.RestHTTP;

namespace API
{
    public class API
    {
        RestHTTP.RestHTTP restHTTP = new RestHTTP.RestHTTP();
        public string Get_PageContent_ByName(string pageName)
        {
            string pageContent = "";

            try
            {
                (HttpStatusCode responseStatusCode, string responseBody, string responseContentType) =
                    restHTTP.SendHTTPRequest(RequestType.GET, $"https://en.wikipedia.org/w/api.php?action=parse&page={pageName}&format=json");

                JObject page = JObject.Parse(responseBody);

                pageContent = page["parse"]["text"]["*"].ToString();

            }
            catch (Exception e)
            {
                Common.Common.Report("TestAutomationPage not found", Common.Common.MessageColor.RED);
            }

            return pageContent;
        }
    }
}
