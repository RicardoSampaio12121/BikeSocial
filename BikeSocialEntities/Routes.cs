namespace BikeSocialEntities
{
    public class Routes
    {
        public int Id { get; set; }
        public int? UsersId { get; set; }
        public bool Public { get; set; }
        public string Description { get; set; }
        public DateTime dateTime { get; set; }
        public float EstimatedTime { get; set; }
        public float Distance { get; set; }
        public int PlacesId { get; set; }
        public int RouteTypesId { get; set; }

        public List<RouteInvites> RouteInvites { get; set; }
    }
}