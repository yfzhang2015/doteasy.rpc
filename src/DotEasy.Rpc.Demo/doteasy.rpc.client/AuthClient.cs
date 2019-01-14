using System;
using System.Net.Http;
using IdentityModel.Client;

namespace doteasy.client
{
    public static class AuthClient
    {
        public static string GetToken()
        {
            var disco = DiscoveryClient.GetAsync("http://127.0.0.1:8080").Result;
            TokenResponse tokenResponse;
            using (var tokenClient = new TokenClient(disco.TokenEndpoint, "ro.client", "secret"))
            {
                tokenResponse = tokenClient.RequestResourceOwnerPasswordAsync("alice", "password", "api1").Result; //使用用户名密码
            }

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return "";
            }

            Console.WriteLine(tokenResponse.Json);
            return tokenResponse.AccessToken;
        }

        public static void TestAllDisco()
        {
            HttpResponseMessage response;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + GetToken());
                response = httpClient.GetAsync(new Uri("http://127.0.0.1:8080/api/values")).Result; // 通过网关访问具体资源
            }

            Console.WriteLine("response: " + response);
            Console.WriteLine("content: " + response.Content.ReadAsStringAsync().Result);
        }
    }
}