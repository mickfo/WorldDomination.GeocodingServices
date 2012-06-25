using WorldDomination.GeocodingServices.Interfaces;

namespace WorldDomination.GeocodingServices.Entities
{
    public class Location : ILocation
    {
        #region Implementation of ILocation

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        #endregion
    }
}