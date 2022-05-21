namespace BikeSocialEntities
{
    public class Profile
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public string description { get; set; }
        public int profileVisibility { get; set; }
        public int commentsPermission { get; set; }
        public bool unfriendContactPermission { get; set; }
        public bool unfriendTrofyVisualization { get; set; }
        public bool privateTrainings { get; set; }
        public bool privateRaces { get; set; }
        public bool privateRoutes { get; set; }

        public List<ProfileAchievements> ProfileAchievements { get; set; } 
    }
}