namespace BikeSocialDTOs
{
    public record ReturnConsultAchievementAthleteDto
    {
        public int athleteId { get; init; }
        public int achievementId { get; init; }  
        public string name { get; init; }    
        public DateTime date { get; init; }
        public string City { get; set; }
        public string PlaceName { get; set; }
        public string NameTypeAchievement { get; set; }
    }

}
