namespace BikeSocialDTOs
{
    public class GetFriendDto
    {
        public int solicitorId { get; set; }
        public int recieptientId { get; set; }
        public bool status { get; set; }
        public DateTime timeSent { get; set; }
    }
}
