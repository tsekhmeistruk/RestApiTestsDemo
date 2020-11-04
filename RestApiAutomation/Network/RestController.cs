using Newtonsoft.Json;
using RestApiAutomation.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace RestApiAutomation
{
    public class RestController
    {
        private NetworkConnection networkController;
        public string EndpointBaseUrl { get; set; }

        public string Token { get; set; }

        public RestController(string endpointUrl)
        {
            this.EndpointBaseUrl = endpointUrl;
            networkController = new NetworkConnection();
        }

        public ResponseModel Get<T>()
        {
            HttpMethod httpMethod = HttpMethod.GET;
            string resource = Helpers.GetDescription<T>();
            string endPoint = $"{EndpointBaseUrl}/{resource}";
            
            var response = networkController.HttpRequest(endPoint: endPoint, 
                                                         httpMethod: httpMethod);
            string responseRawData = Helpers.ResponseDataToJson(response);
            ResponseDataModel<T> responseData = JsonConvert.DeserializeObject<ResponseDataModel<T>>(responseRawData);
            return Helpers.CreateResponseModel<ResponseDataModel<T>>(responseData, response.StatusCode);
        }

        public ResponseModel Get<T>(int id)
        {
            HttpMethod httpMethod = HttpMethod.GET;
            string resource = Helpers.GetDescription<T>();
            string endPoint = $"{EndpointBaseUrl}/{resource}/{id}";

            var response = networkController.HttpRequest(endPoint: endPoint,
                                                         httpMethod: httpMethod);
            string responseRawData = Helpers.ResponseDataToJson(response);
            T entity = Helpers.Deserialize<T>(responseRawData);
            return Helpers.CreateResponseModel<T>(entity, response.StatusCode);
        }

        public ResponseModel Post<T>(T entity)
        {
            HttpMethod httpMethod = HttpMethod.POST;
            string resource = Helpers.GetDescription<T>();
            string endPoint = $"{EndpointBaseUrl}/{resource}";
            var headers = new Dictionary<HttpRequestHeader, string>()
            {
                { HttpRequestHeader.Authorization, Token }
            };

           
            string bodyRawJson = Helpers.Serialize(entity);
            var response = networkController.HttpRequest(endPoint: endPoint, 
                                                         httpMethod: httpMethod,
                                                         headers: headers,
                                                         bodyData: bodyRawJson, 
                                                         parameters:String.Empty, 
                                                         contentType: "text/json");
            string entityId = Helpers.ResponseDataToJson(response);
            return Helpers.CreateResponseModel<string>(entityId, response.StatusCode);
        }

        public ResponseModel Put<T>(T entity, int id)
        {
            HttpMethod httpMethod = HttpMethod.PUT;
            string resource = Helpers.GetDescription<T>();
            string endPoint = $"{EndpointBaseUrl}/{resource}/{id}";
            var headers = new Dictionary<HttpRequestHeader, string>()
            {
                { HttpRequestHeader.Authorization, Token }
            };

            string bodyRawJson = Helpers.Serialize(entity);
            var response = networkController.HttpRequest(endPoint: endPoint,
                                                         httpMethod: httpMethod,
                                                         headers: headers,
                                                         bodyData: bodyRawJson,
                                                         parameters: String.Empty,
                                                         contentType: "text/json");
            return Helpers.CreateResponseModel(response.StatusCode);
        }

        public ResponseModel Delete<T>(int id)
        {
            HttpMethod httpMethod = HttpMethod.DELETE;
            string resource = Helpers.GetDescription<T>();
            string endPoint = $"{EndpointBaseUrl}/{resource}/{id}";
            var headers = new Dictionary<HttpRequestHeader, string>()
            {
                { HttpRequestHeader.Authorization, Token }
            };
            var response = networkController.HttpRequest(endPoint: endPoint,
                                                         httpMethod: httpMethod,
                                                         headers: headers);
            return Helpers.CreateResponseModel(response.StatusCode);
        }
    }
}
