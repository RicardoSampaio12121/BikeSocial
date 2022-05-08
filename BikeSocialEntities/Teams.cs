namespace BikeSocialEntities
{
    public class Teams
    {
        public int Id { get; set; }
        public int ClubsId { get; set; }
        public string Name { get; set; }
        public int? PlacesId { get; set; }
        public int? FederationsId { get; set; }

        public List<Athletes> Athletes { get; set; }
        public List<TeamInviteAthletes> TeamInviteAthletes { get; set; }
        public List<Coaches> Coaches { get; set; }
        public List<TeamInviteCoaches> TeamInviteCoaches { get; set; }
        public List<Trainings> Trainings { get; set; }
        public List<TeamFederationRequests> TeamFederationsRequests { get; set; }
    }
}
