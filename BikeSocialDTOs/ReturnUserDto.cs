namespace BikeSocialDTOs
{
    public record ReturnUserDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
    }
}
