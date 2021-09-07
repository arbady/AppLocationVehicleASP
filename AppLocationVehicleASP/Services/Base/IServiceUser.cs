using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Services.Base
{
    public interface IServiceUser<T, U>
        where T : class
        where U : class
    {
        int Login(string email, string password);
        bool Delete(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(U form);
        void Update(U form);
    }
}
