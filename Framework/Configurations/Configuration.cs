using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Configurations
{
    public static class Configuration
    {
        public static string StartUrl => Environment.CurrentEnvironment.GetValue<string>(".startUrl");

        public static string ApiUrl => Environment.CurrentEnvironment.GetValue<string>(".apiUrl");
    }
}
