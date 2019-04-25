using System.Collections.Generic;

namespace Swgoh.Dto.Requests
{
    public class GuildsRequest : BaseRequest
    {
        public List<int> AllyCodes { get; set; }
        public string Language { get; set; }
        public bool? Enums { get; set; }
    }
}
