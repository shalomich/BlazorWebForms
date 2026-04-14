using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorWebForms.Web.Common.DI
{
    public class AppSettings
    {
        public string NewAppBasePath { get; set; }

        public string LegacyAppBasePath { get; set; }

        public string RedisConnection { get; set; }
    }
}
