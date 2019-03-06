using IdentityModel.Client;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace Identity4ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CallAPIAsync();
            Console.ReadLine();
        }

        static async void CallAPIAsync()
        {
            var discoveryClient = new DiscoveryClient("https://localhost:44346");
            var disco = await discoveryClient.GetAsync();
            // request token
            var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api1");

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            var response = await client.GetAsync("https://localhost:44365/identity");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content));
            }
        }
    }


}
