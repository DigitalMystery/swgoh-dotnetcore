using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Swgoh.Service
{
    public class JsonContent : StringContent
    {
        public JsonContent(object obj) :
            base(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/x-www-form-urlencoded")
        { }
    }
}
