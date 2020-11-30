using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assignment4.Models
{
    public class Family
    {

        //public int Id { get; set; }
       
        [JsonPropertyName("StreetName"),Key]
        public string StreetName { get; set; }
        [JsonPropertyName("HouseNumber")]
        public int HouseNumber { get; set; }
        [JsonPropertyName("Adults")]
        public List<Adult> Adults { get; set; }
        [JsonPropertyName("Children")]
        public List<Child> Children { get; set; }
        [JsonPropertyName("Pets")]
        public List<Pet> Pets { get; set; }

        public Family()
        {
            Adults = new List<Adult>();
            Children = new List<Child>();
            Pets = new List<Pet>();
        }

    }


}