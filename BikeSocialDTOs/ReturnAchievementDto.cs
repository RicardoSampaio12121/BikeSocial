namespace BikeSocialDTOs
{
    public record ReturnAchievementDto
    {
        public string Name { get; set; }
        public int AchievementTypeId { get; set; }
        public float achievementTime { get; set; }
        public DateTime date { get; set; }
        public int PlacesId { get; set; }
    }
}