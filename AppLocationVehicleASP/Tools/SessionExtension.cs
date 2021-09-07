using AppLocationVehicleASP.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Tools
{
    public static class SessionExtension
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }

        //public static void SetUser(this ISession session, User user)
        //{
        //    session.Set("user", user);
        //}
        //public static User GetUser(this ISession session)
        //{
        //    return session.Get<User>("user");
        //}
    }
}
