namespace BikeSocialEntities
{
    public class AthleteFederationRequests
    {
        public int Id { get; set; }
        public int AthletesId { get; set; }
        public int? FederationsId { get; set; }
        public string? Status { get; set; }
    }
}
