namespace BikeSocialEntities
{
    public class Achievements
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AchievementTypesId { get; set; }
        public int PlacesId { get; set; }
        
        public List<AthleteAchievements> AthleteAchievements { get; set; }
        
    }
}