using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApplication.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string root = "api";

        public const string version = "V1";

        public const string Base = root +"/" + version;


        public static class WeatherForecast
        {
            public const string GetAll = Base+"/WeatherForecast";
        }
    }
}
