namespace BikeSocialEntities
{
    public class AthleteAchievements
    {
        public int Id { get; set; }
        public int AthleteId { get; set; }
        public int AchievementId { get; set; }
        public DateTime AchievementDate { get; set; }
    }
}