using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Tools
{
    public interface ISecurity
    {
        public TResult Get<TResult>(string Uri);
        public void Post<TBody>(TBody body, string uri);
        public TResult Post<TBody, TResult>(TBody body, string uri);
        public TResult Post<TBody, TResult>(TBody body, string uri, string token);
        public void Update<TBody>(TBody body, string uri);
        public void Delete(int id, string uri);
    }
}
