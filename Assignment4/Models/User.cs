﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Assignment4.Models
{
    public class User
    {
        [JsonPropertyName("ID"),Key]
        public int ID { get; set; }
        [JsonPropertyName("UserName")]
        public string UserName { get; set; }
        [JsonPropertyName("City")]
        public string City { get; set; }
        [JsonPropertyName("BirthYear")]
        public int BirthYear { get; set; }
        [JsonPropertyName("Role")]
        public string Role { get; set; }
        [JsonPropertyName("SecurityLevel")]
        public int SecurityLevel { get; set; }
        [JsonPropertyName("Password")]
        public string Password { get; set; }
    }
}
