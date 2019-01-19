using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ChiJunKaiOAMis.Models
{
    public class Pager
    {
        public static String PagedData<T>(List<T> list, int count, String dateTimeFormat = "yyyy-MM-dd HH:mm:ss")
        {
            StringBuilder strJson = new StringBuilder();
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
            settings.DateFormatString = dateTimeFormat;
            settings.MaxDepth = 1; //设置序列化的最大层数  
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings.NullValueHandling = NullValueHandling.Ignore;
            foreach (var item in list)
            {
                strJson.Append(JsonConvert.SerializeObject(item, settings) + ",");
            }
            return "{\"code\":0,\"msg\":\"\",\"count\":" + count + ",\"data\":[" + strJson.ToString().TrimEnd(',') + "]}";
        }
    }
}