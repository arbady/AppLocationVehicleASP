using AppLocationVehicleASP.Bases;
using AppLocationVehicleASP.Models;
using AppLocationVehicleASP.Models.Forms;
using AppLocationVehicleASP.Service.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Services
{
    public class AgencyService : BaseService, IService<Agency, AgencyForm>
    {
        public AgencyService() : base("Agency"){}
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Agency> GetAll()
        {
            throw new NotImplementedException();
        }

        public Agency GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(AgencyForm form)
        {
            throw new NotImplementedException();
        }

        public void Update(AgencyForm form)
        {
            throw new NotImplementedException();
        }
    }
}
