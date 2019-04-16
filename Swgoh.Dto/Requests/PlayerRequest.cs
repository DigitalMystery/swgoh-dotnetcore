using System.Collections.Generic;

namespace Swgoh.Dto.Requests
{
    public class PlayerRequest
    {
        //TODO - Make a base entity
        public List<int> AllyCodes { get; set; }
        public string Language { get; set; }
        public bool? Enums { get; set; }
        public string Structure { get; set; }
        public object Project { get; set; }
    }
}
