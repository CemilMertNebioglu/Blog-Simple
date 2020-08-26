using BloggerSample.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggerSample.WebUI.Core
{
    public static class BloggerConvert
    {
        public static string BloggerJsonSerialize(object data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return json;
        }

        public static UserDTO BloggerJsonDeSerializeUserDTO(string data)
        {
            return JsonConvert.DeserializeObject<UserDTO>(data);
        }

    }
}
