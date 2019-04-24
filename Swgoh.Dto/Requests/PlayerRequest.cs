namespace Swgoh.Dto.Requests
{
    public class PlayerRequest : BaseRequest
    {
        public int AllyCode { get; set; }
        public string Language { get; set; }
        public bool? Enums { get; set; }
    }
}
