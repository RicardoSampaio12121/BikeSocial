namespace BikeSocialEntities
{
    public class Achievements
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AchievementTypeId { get; set; }
        public float achievementTime { get; set; }
        public DateTime dateTime { get; set; }
        public int PlacesId { get; set; }
    }
}