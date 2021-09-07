using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Tools
{
    public class Security : ISecurity
    {
        private HttpClient _client;
        public Security(string baseAdress)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseAdress);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
           // _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        

        public TResult Get<TResult>(string uri)
        {
            using (HttpResponseMessage message = _client.GetAsync(uri).Result)
            {
                message.EnsureSuccessStatusCode();
                string json = message.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<TResult>(json);
            }
        }
        public TResult Get<TResult>(string uri, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return this.Get<TResult>(uri);
        }

        public TResult Post<TBody, TResult>(TBody body, string uri, string token)
        {

            string json = JsonConvert.SerializeObject(body);
            if (token != null) _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token); /*return client;*/

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage message = _client.PostAsync(uri, content).Result;

            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
            json = message.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TResult>(json);
        }
        public TResult Post<TBody, TResult>(TBody body, string uri)
        {
            string json = JsonConvert.SerializeObject(body);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage message = _client.PostAsync(uri, content).Result;

            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
            json = message.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TResult>(json);
        }
        public void Post<TBody>(TBody body, string uri)
        {
            string json = JsonConvert.SerializeObject(body);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage message = _client.PostAsync(uri, content).Result;

            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        }

        public void Update<TBody>(TBody body, string uri)
        {
            string json = JsonConvert.SerializeObject(body);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage message = _client.PutAsync(uri, content).Result;

            if (!message.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
        }

        public void Delete(int id, string uri)
        {
            HttpResponseMessage message = _client.DeleteAsync(uri + id).Result;
            message.EnsureSuccessStatusCode();
        }

        //public TResult Login<TBody, TResult>(TBody body, string uri, string token)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
