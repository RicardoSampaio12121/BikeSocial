namespace BikeSocialDTOs
{
    public record GetUserRegisterDto
    {
        public string username { get; set; }
        public string password { get; set; }
        public DateTime birthdate { get; set; }
        public int contact { get; set; }
        public int placeId { get; set; }
        public int userTypeId { get; set; }
    }
}
