namespace BikeSocialEntities
{
    public class RouteInvites
    {
        public int Id { get; set; }
        //TODO: Mudar UsersId para AthletesId
        public int? UsersId { get; set; } 
        public int RoutesId { get; set; }
        public bool Confirmation { get; set; } //Fez o invite, n�o sei se era s� isto
    }
}