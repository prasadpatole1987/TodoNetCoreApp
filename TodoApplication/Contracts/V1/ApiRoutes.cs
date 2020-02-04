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


        public static class Todo
        {
            public const string GetAll = Base + "/Todo";

            public const string Get = Base + "/Todo/{id}";

            public const string Create = Base + "/Todo";

            public const string Update = Base + "/Todo/{id}";

            public const string Delete = Base + "/Todo/{id}";


        }
    }
}
