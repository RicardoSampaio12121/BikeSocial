namespace BikeSocialEntities
{
    public class Coaches
    {
        public int Id { get; set; }
        public int? UsersId { get; set; }
        public int? TeamsId { get; set; }

        public List<TeamInviteCoaches> TeamInviteCoaches { get; set; }
    }
}
