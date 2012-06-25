namespace WorldDomination.GeocodingServices.Services.Yahoo
{
    public class Result
    {
        public int Quality { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Offsetlat { get; set; }
        public string Offsetlon { get; set; }
        public int Radius { get; set; }
        public string Name { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }
        public string House { get; set; }
        public string Street { get; set; }
        public string Xstreet { get; set; }
        public string Unittype { get; set; }
        public string Unit { get; set; }
        public string Postal { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Countrycode { get; set; }
        public string Statecode { get; set; }
        public string Countycode { get; set; }
        public string Uzip { get; set; }
        public string Hash { get; set; }
        public int Woeid { get; set; }
        public int Woetype { get; set; }
    }
}