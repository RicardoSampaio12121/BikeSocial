namespace BikeSocialEntities
{
    public class RouteInvites
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int RoutesId { get; set; }
        public bool Confirmation { get; set; }
    }
}