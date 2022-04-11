namespace BikeSocialDTOs
{
    public record ReturnUserDto
    {
        public int id { get; set; }
        public string username { get; set; }
        public string birthDate { get; set; }
        public int contact { get; set; }
        public int placeId { get; set; }
        public int userTypeId { get; set; }
        public string email { get; set; }
    }

    
}
