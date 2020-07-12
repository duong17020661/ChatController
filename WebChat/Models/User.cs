
using System;
using System.Text.Json.Serialization;

namespace WebChat.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string username { get; set; }
        [JsonIgnore]
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string avatar { get; set; }
        public string email { get; set; }
        public int phone { get; set; }
        public string lastMessage { get; set; }
        public bool status { get; set; }
        public int newMessage { get; set; }
        public DateTime lastSeen { get; set; }
        

    }
}