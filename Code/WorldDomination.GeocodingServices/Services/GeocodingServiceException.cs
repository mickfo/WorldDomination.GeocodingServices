using System;

namespace WorldDomination.GeocodingServices.Services
{
    public class GeocodingServiceException : Exception
    {
        public GeocodingServiceException(string errorMessage) : base(errorMessage)
        {}
    }
}