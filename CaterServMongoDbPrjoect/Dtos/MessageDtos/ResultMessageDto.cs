﻿namespace CaterServMongoDbPrjoect.Dtos.MessageDtos
{
    public class ResultMessageDto
    {
        public string MessageId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime Date { get; set; }
    }
}
