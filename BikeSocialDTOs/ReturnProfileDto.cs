namespace BikeSocialDTOs
{
    public record ReturnProfileDto
    {
        public int profileId { get; set; }
        public int userId {get; set;}
        public string description { get; set; }
        public int profileVisibility { get; set; }
    }
}
