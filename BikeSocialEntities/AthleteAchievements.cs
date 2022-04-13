namespace BikeSocialEntities
{
    public class AthleteAchievements
    {
        public int Id { get; set; }
        public int AthletesId { get; set; }
        public int AchievementsId { get; set; }
        public DateTime AchievementDate { get; set; }
    }
}