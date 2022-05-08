namespace BikeSocialEntities
{
    public class TeamInviteCoaches
    {
        public int Id { get; set; }
        public int? TeamsId { get; set; }
        public int CoachesId { get; set; }
    }
}
