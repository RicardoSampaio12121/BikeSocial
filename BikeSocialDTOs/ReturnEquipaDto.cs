namespace BikeSocialDTOs
{
   
    public record ReturnEquipaDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public int? placeId { get; set; }
        public int clubeId { get; set; }
    }
}
