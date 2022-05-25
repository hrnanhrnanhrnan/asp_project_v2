using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace candyshop_project.Models
{
    public class Symbol
    {
        [JsonPropertyName("symbols")]
        public List<string> Symbols { get; set; }
    }
}
