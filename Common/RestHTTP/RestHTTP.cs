using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestHTTP
{
    public class RestHTTP
    {
        //protected static readonly NLog.Logger Log = NLog.LogManager.GetCurrentClassLogger();
        public enum RequestType
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        private RestClient client;
        public RestHTTP()
        {
            client = new RestClient();
        }

        public (HttpStatusCode, string, string) SendHTTPRequest(string authUser, string authPass, RequestType requestType, String URL, String body)
        {
            RestRequest request;
            RestResponse response = null;

            string statusCode = "";
            string responseBody = "";
            string responseContentType = "";

            string authHeaderValue = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{authUser}:{authPass}"));

            try
            {

                switch (requestType)
                {
                    case RequestType.GET:
                        request = new RestRequest(URL, Method.Get);
                        request.AddHeader("Authorization", $"Basic {authHeaderValue}");
                        request.AddParameter("application/json", body, ParameterType.RequestBody);                        
                        response = client.Execute(request);
                        break;

                    case RequestType.POST:
                        request = new RestRequest(URL, Method.Post);
                        request.AddHeader("Authorization", $"Basic {authHeaderValue}");
                        request.AddParameter("application/json", body, ParameterType.RequestBody);                        
                        response = client.Execute(request);
                        break;

                    case RequestType.PUT:
                        request = new RestRequest(URL, Method.Put);
                        request.AddHeader("Authorization", $"Basic {authHeaderValue}");
                        request.AddParameter("application/json", body, ParameterType.RequestBody);                        
                        response = client.Execute(request);
                        break;

                    case RequestType.DELETE:
                        request = new RestRequest(URL, Method.Delete);
                        request.AddHeader("Authorization", $"Basic {authHeaderValue}");
                        request.AddParameter("application/json", body, ParameterType.RequestBody);                        
                        response = client.Execute(request);
                        break;
                }                

            }
            catch (HttpRequestException e)
            {
                //Log.Error("sendHTTPRequest :{0} ", e.Message);
            }

            if (response.Content == null)
            {
                response.Content = "";
            }

            return (response.StatusCode, response.Content.ToString(), response.ContentType);
        }

        public (HttpStatusCode, string, string) SendHTTPRequest(RequestType requestType, String URL, String body)
        {
            RestRequest request;
            RestResponse response = null;

            string statusCode = "";
            string responseBody = "";
            string responseContentType = "";

            try
            {

                switch (requestType)
                {
                    case RequestType.GET:
                        request = new RestRequest(URL, Method.Get);
                        request.AddParameter("application/json", body, ParameterType.RequestBody);                        
                        response = client.Execute(request);
                        break;

                    case RequestType.POST:
                        request = new RestRequest(URL, Method.Post);
                        request.AddParameter("application/json", body, ParameterType.RequestBody);                        
                        response = client.Execute(request);
                        break;

                    case RequestType.PUT:
                        request = new RestRequest(URL, Method.Put);
                        request.AddParameter("application/json", body, ParameterType.RequestBody);                        
                        response = client.Execute(request);
                        break;

                    case RequestType.DELETE:
                        request = new RestRequest(URL, Method.Delete);
                        request.AddParameter("application/json", body, ParameterType.RequestBody);                        
                        response = client.Execute(request);
                        break;
                }                

            }
            catch (HttpRequestException e)
            {
                //Log.Error("sendHTTPRequest :{0} ", e.Message);
            }

            if (response.Content == null)
            {
                response.Content = "";
            }

            return (response.StatusCode, response.Content.ToString(), response.ContentType);
        }

        public (HttpStatusCode, string, string) SendHTTPRequest(RequestType requestType, String URL)
        {
            RestRequest request;
            RestResponse response = null;

            string statusCode = "";
            string responseBody = "";
            string responseContentType = "";

            try
            {

                switch (requestType)
                {
                    case RequestType.GET:
                        request = new RestRequest(URL, Method.Get);
                        request.AddParameter("application/json", "", ParameterType.RequestBody);                        
                        response = client.Execute(request);
                        break;

                    case RequestType.POST:
                        request = new RestRequest(URL, Method.Post);
                        request.AddParameter("application/json", "", ParameterType.RequestBody);                        
                        response = client.Execute(request);
                        break;

                    case RequestType.PUT:
                        request = new RestRequest(URL, Method.Put);
                        request.AddParameter("application/json", "", ParameterType.RequestBody);                        
                        response = client.Execute(request);
                        break;

                    case RequestType.DELETE:
                        request = new RestRequest(URL, Method.Delete);
                        request.AddParameter("application/json", "", ParameterType.RequestBody);                        
                        response = client.Execute(request);
                        break;
                }                

            }
            catch (HttpRequestException e)
            {
                //Log.Error("sendHTTPRequest :{0} ", e.Message);
            }

            return (response.StatusCode, response.Content.ToString(), response.ContentType);
        }
    }
}
