using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GeeKang.Models
{
    public class Project
    {
        public string Html_Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public static List<Project> GetProjects()
        {
            var client = new RestClient("https://api.github.com/");

            var request = new RestRequest("/users/jiwonk42/starred", Method.GET);
            request.AddHeader("User-Agent", "jiwonk42");

            var response = new RestResponse();

            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();

            JArray projectArray = JsonConvert.DeserializeObject<JArray>(response.Content);

            string jsonOutput = projectArray.ToString();
            var projectList = JsonConvert.DeserializeObject<List<Project>>(jsonOutput);

            return projectList;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }

    }
}