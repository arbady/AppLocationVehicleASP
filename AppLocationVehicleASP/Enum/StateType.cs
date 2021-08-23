using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLocationVehicleASP.Enum
{
    public enum StateType
    {
        [Display(Name = "En agence")]
        AGENCE,

        [Display(Name="En location")]
        LOCATION,

        [Display(Name = "Au garage")]
        GARAGE
    }
    public static class TestEnumExtension
    {
        private readonly static Dictionary<StateType, string> mapper = new ()
        {
            { StateType.AGENCE, "En agence" },
            { StateType.LOCATION, "En location"},
            { StateType.GARAGE, "Au garage" }
        };
        public static string ToStringValue(this StateType value) => mapper[value];
    }
}
