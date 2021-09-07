using AppLocationVehicleASP.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Tools
{
    public static class SessionUtils
    {
        static IServiceProvider services = null;

        /// <summary>
        /// Provides static access to the framework's services provider
        /// </summary>
        public static IServiceProvider Services
        {
            private get { return services; }
            set
            {
                if (services != null)
                {
                    throw new Exception("Can't set once a value has already been set.");
                }
                services = value;
            }
        }

        /// <summary>
        /// Provides static access to the current HttpContext
        /// </summary>
        private static HttpContext Current
        {
            get
            {
                IHttpContextAccessor httpContextAccessor = Services.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor;
                return httpContextAccessor?.HttpContext;
            }
        }

        public static User ConnectedUser
        {
            get { return Current.Session.Get<User>("ConnectedUser"); }
            set { Current.Session.Set<User>("ConnectedUser", value); }
        }

        public static bool IsLogged
        {
            get { return Current.Session.Get<bool>("IsLogged"); }
            set { Current.Session.Set<bool>("IsLogged", true); } // peut etre value à la place de true selon samuel
        }

    }
}
