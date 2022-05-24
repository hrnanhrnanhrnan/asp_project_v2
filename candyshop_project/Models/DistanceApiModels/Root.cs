using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace candyshop_project.Models.DistanceApiModels
{
    public class Distance
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }
    }

    public class Duration
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("value")]
        public int Value { get; set; }
    }

    public class Element
    {
        [JsonPropertyName("distance")]
        public Distance Distance { get; set; }

        [JsonPropertyName("duration")]
        public Duration Duration { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("destination_addresses")]
        public List<string> DestinationAddresses { get; set; }

        [JsonPropertyName("origin_addresses")]
        public List<string> OriginAddresses { get; set; }

        [JsonPropertyName("rows")]
        public List<Row> Rows { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

    public class Row
    {
        [JsonPropertyName("elements")]
        public List<Element> Elements { get; set; }
    }
}
