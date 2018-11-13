using Newtonsoft.Json;
using XFArchitecture.Core.Utilities;
using System.ComponentModel.DataAnnotations.Schema;

namespace XFArchitecture.Core.Models
{
    public class BaseEntity : ObservableObject
    {
        [NotMapped]
        [JsonProperty(PropertyName = "Status")]
        public int Status { get; set; }

        [NotMapped]
        [JsonProperty(PropertyName = "Message")]
        public string Message { get; set; }
    }
}