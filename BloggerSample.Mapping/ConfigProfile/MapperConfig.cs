using System;
using System.Collections.Generic;
using System.Text;

namespace BloggerSample.Mapping.ConfigProfile
{
    public class MapperConfig
    {
        public static void RegisterMappers()
        {
            MapperFactory.RegisterMappers();
        }
    }
}
