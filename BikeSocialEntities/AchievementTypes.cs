namespace BikeSocialEntities
{
    public class AchievementTypes
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Achievements> Achievements { get; set; }
    }
}