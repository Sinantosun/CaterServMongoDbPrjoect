namespace CaterServMongoDbPrjoect.Dtos.BookingDtos
{
    public class UpdateBookingDto
    {
        public string BookingID { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Neighbourhood { get; set; }
        public string NameSurname { get; set; }
        public string PersonCount { get; set; }
        public bool IsVegeteratian { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string EventCategoriesId { get; set; }
    }
}
