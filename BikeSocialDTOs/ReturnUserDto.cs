namespace BikeSocialDTOs
{
    public record ReturnUserDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
    }

    public record ReturnEquipaDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string local { get; set; }
    }
}
