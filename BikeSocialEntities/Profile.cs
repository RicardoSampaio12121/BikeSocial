namespace BikeSocialEntities
{
    public class Profile
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public string description { get; set; }
        public int profileVisibility { get; set; }
        public List<ProfileAchievements> ProfileAchievements { get; set; } 
    }
}