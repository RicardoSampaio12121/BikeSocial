namespace BikeSocialEntities
{
    public class PasswordRecoveryCodes
    {
        public int Id { get; set; }
        public int UsersId { get; set; }
        public int code { get; set; }
        public int requestDate { get; set; }
    }
}
