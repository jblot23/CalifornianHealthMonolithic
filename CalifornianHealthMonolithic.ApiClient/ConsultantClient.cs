using CalifornianHealthMonolithic.DTO.Consultant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;

namespace CalifornianHealthMonolithic.ApiClient
{
    public static class ConsultantClient
    {
        /// <summary>
        /// Fetct consultants
        /// </summary>
        /// <returns></returns>
        public static async Task<List<ConsultantDto>> FetchConsultant()
        {
            // Create a new RestClient with the base URL
            var client = new RestClient("https://localhost:44364");

            // Create a new RestRequest with the endpoint and method
            var request = new RestRequest("api/Consultant", Method.Get);

            // Add the Accept header
            request.AddHeader("Accept", "application/json");

            // Execute the request and get the response
            var response = client.Execute(request);

            var consultantDtos = JsonConvert.DeserializeObject<List<ConsultantDto>>(response.Content);


            return consultantDtos;
        }
    }
}
