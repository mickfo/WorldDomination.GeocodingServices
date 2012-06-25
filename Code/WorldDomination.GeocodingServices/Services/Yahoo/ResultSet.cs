using System.Collections.Generic;

namespace WorldDomination.GeocodingServices.Services.Yahoo
{
    public class ResultSet
    {
        public string Version { get; set; }
        public int Error { get; set; }
        public string ErrorMessage { get; set; }
        public string Locale { get; set; }
        public int Quality { get; set; }
        public int Found { get; set; }
        public List<Result> Results { get; set; }
    }
}