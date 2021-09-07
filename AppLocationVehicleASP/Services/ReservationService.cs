using AppLocationVehicleASP.Bases;
using AppLocationVehicleASP.Models;
using AppLocationVehicleASP.Models.Forms;
using AppLocationVehicleASP.Service.Bases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Services
{
    public class ReservationService : BaseService, IService<Reservation, ReservationForm>
    {
        public ReservationService() : base("Reservation"){}
        public bool Delete(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync(new Uri(
                baseAddress.ToString() + "Reservation/" + id.ToString())).Result;
            
            if (!response.IsSuccessStatusCode) throw new HttpRequestException();
            string jsonString = GetJsonContent(response);

            return true;
        }

        public IEnumerable<Reservation> GetAll()
        {
            using (HttpClient client = CreateHttpClient())
            {
                HttpResponseMessage response = GetResponseMessage(client.GetAsync);
                if (!response.IsSuccessStatusCode) throw new HttpRequestException();
                string jsonString = GetJsonContent(response);
                return JsonConvert.DeserializeObject<IEnumerable<Reservation>>(jsonString);
            }
        }

        public IEnumerable<Reservation> GetAllById(int id)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = client.GetAsync(new Uri(
                baseAddress.ToString() + "Reservation/User/" + id.ToString())).Result;

            if (!response.IsSuccessStatusCode) throw new HttpRequestException();
            string jsonString = GetJsonContent(response);
            return JsonConvert.DeserializeObject<IEnumerable<Reservation>>(jsonString); ;
        }


        public Reservation GetById(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(new Uri(baseAddress.ToString() + "Reservation/" + id)).Result;
            if (!response.IsSuccessStatusCode) throw new HttpRequestException();
            string jsonString = GetJsonContent(response);
            return JsonConvert.DeserializeObject<Reservation>(jsonString);
        }

        public void Insert(ReservationForm form)
        {
            Reservation reservation = new Reservation 
            {
                StartDateLocation = form.StartDateLocation,
                EndDateLocation = form.EndDateLocation,
                ReturnAgency = form.ReturnAgency,
                DamageCover = form.DamageCover,
                RobberyCover = form.RobberyCover,
                AgeRange = form.AgeRange,
                UserId = form.UserId,
                AgencyId = form.AgencyId,
                CategoryId = form.CategoryId
            };
            JsonContent entityJson = JsonContent.Create(reservation);

            using (HttpClient client = CreateHttpClient())
            {
                HttpResponseMessage response = GetResponseMessage(client.PostAsync, entityJson);
                if (!response.IsSuccessStatusCode) throw new HttpRequestException();
                string jsonString = GetJsonContent(response);
            }
        }

        public void Update(ReservationForm form)
        {
            Reservation reservation = new Reservation
            {
                StartDateLocation = form.StartDateLocation,
                EndDateLocation = form.EndDateLocation,
                ReturnAgency = form.ReturnAgency,
                DamageCover = form.DamageCover,
                RobberyCover = form.RobberyCover,
                AgeRange = form.AgeRange,
                UserId = form.UserId,
                AgencyId = form.AgencyId,
                CategoryId = form.CategoryId
            };
            JsonContent entityJson = JsonContent.Create(reservation);

            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.PutAsync(new Uri(baseAddress.ToString() + "Reservation/" + form.Id.ToString()), entityJson).Result;
            if (!response.IsSuccessStatusCode) throw new HttpRequestException();
            string jsonString = GetJsonContent(response);
        }
    }
}
