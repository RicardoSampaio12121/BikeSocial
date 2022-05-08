namespace BikeSocialEntities
{
    public class Federations
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Teams> Teams { get; set; }
        public List<Athletes> Athletes { get; set; }
        public List<Races> Races { get; set; }
        public List<TeamFederationRequests> TeamsFederationsRequest { get; set; }
        public List<AthleteFederationRequests> AthleteFederationRequests { get; set; }

    }
}
