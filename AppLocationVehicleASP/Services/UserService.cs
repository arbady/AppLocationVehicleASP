using AppLocationVehicleASP.Bases;
using AppLocationVehicleASP.Models;
using AppLocationVehicleASP.Models.Forms;
using AppLocationVehicleASP.Service.Bases;
using AppLocationVehicleASP.Services.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Services
{
    public class UserService : BaseService, IServiceUser<User, UserForm>
    {
        public UserService() : base("User") { }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(UserForm form)
        {
            throw new NotImplementedException();
        }

        public int Login(string email, string password)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(new Uri(baseAddress.ToString() + "Security/Login/" + email + "/" + password)).Result;
            if (!response.IsSuccessStatusCode) throw new HttpRequestException();
            string jsonString = GetJsonContent(response);
            return JsonConvert.DeserializeObject<int>(jsonString);

            //HttpClient client = new HttpClient();

            //var token = string.Empty;
            //try
            //{
            //    var keyValues = new List<KeyValuePair<string, string>>
            //    {
            //        new KeyValuePair<string, string>("email", email),
            //        new KeyValuePair<string, string>("pwd", password),
            //        new KeyValuePair<string, string>("grant_type", "pwd")
            //    };

            //    HttpResponseMessage response = client.GetAsync(new Uri(baseAddress.ToString() + "Security/Login/" + email + "/" + password)).Result;
            //    var request = new HttpRequestMessage(HttpMethod.Post, "token");
            //    request.Content = new FormUrlEncodedContent(keyValues);

            //    var reponse = client.SendAsync(request).Result;

            //    using (HttpContent content = reponse.Content)
            //    {
            //        string jsonString = GetJsonContent(response);
            //        //return JsonConvert.DeserializeObject<int>(jsonString);
            //        var json = content.ReadAsStringAsync();
            //        JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jsonString);
            //        var accessTokenExpires = jwtDynamic.Value<DateTime>(".expires");
            //        token = jwtDynamic.Value<string>("access_token");
            //        var userName = jwtDynamic.Value<string>("userName");
            //        var accessTokenExpirationDate = accessTokenExpires;
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            //return this.Login(email, password);
        }

        public void Update(UserForm form)
        {
            throw new NotImplementedException();
        }
    }
}
