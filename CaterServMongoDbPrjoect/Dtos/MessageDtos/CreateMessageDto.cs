namespace CaterServMongoDbPrjoect.Dtos.MessageDtos
{
    public class CreateMessageDto
    {

        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime Date { get; set; }


    }
}
