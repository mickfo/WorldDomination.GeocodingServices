namespace WorldDomination.GeocodingServices.Interfaces
{
    public interface IGeocodingService
    {
        ILocation Geocode(string address);
    }
}