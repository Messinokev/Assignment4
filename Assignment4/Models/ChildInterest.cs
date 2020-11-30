using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assignment4.Models
{
public class ChildInterest {
        [JsonPropertyName("ChildId")]
        public int ChildId { get; set; }
        [JsonIgnore]
        public Child Child { get; set; }
        [JsonPropertyName("InterestId"), Key]
        public string InterestId { get; set; }
        [JsonIgnore]
        public Interest Interest { get; set; }

        public override bool Equals(object? obj) {
        ChildInterest ci = ((ChildInterest) obj);
        if (ci.Child.Equals(Child) && ci.Interest.Equals(Interest)) return true;
        return base.Equals(obj);
    }
}
}