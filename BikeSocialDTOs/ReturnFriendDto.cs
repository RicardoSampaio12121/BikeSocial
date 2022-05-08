namespace BikeSocialDTOs
{
    public record ReturnFriendDto
    {
        public int solicitorId { get; set; }
        public int receiptientId { get; set; }
        public bool status { get; set; }
        public DateTime timeSent { get; set; }
    }
}
