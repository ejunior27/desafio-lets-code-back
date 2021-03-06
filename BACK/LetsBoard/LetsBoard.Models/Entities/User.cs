using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LetsAuth.Models.Entities

{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
    }
}
