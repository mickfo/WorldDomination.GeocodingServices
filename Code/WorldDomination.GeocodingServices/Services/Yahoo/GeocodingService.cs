using System;
using System.Linq;
using CuttingEdge.Conditions;
using RestSharp;
using WorldDomination.GeocodingServices.Entities;
using WorldDomination.GeocodingServices.Interfaces;

namespace WorldDomination.GeocodingServices.Services.Yahoo
{
    public class GeocodingService : IGeocodingService
    {
        private readonly string _appId;
        private readonly IRestClient _restClient;

        public GeocodingService(string appId) : this(appId, null)
        {
        }

        public GeocodingService(string appId, IRestClient restClient)
        {
            Condition.Requires(appId).IsNotNullOrEmpty(
                "A Yahoo PlaceFinder application Id is required, to access their API.");
            _appId = appId;

            // RestClient -can- be null. If it is -not- null, it's probably a mock :)
            _restClient = restClient;
        }

        #region Implementation of IGeocodingService

        public ILocation Geocode(string address)
        {
            Condition.Requires(address).IsNotNullOrEmpty(
                "The Yahoo PlaceFinder API requires an address before it can geocode something!");

            // Sample: http://where.yahooapis.com/geocode?q=1600+Pennsylvania+Avenue,+Washington,+DC&appid=[yourappidhere]&flags=j
            // Docs: http://developer.yahoo.com/geo/placefinder/guide/requests.html

            var restClient = _restClient ?? new RestClient("http://where.yahooapis.com/geocode");
            var restRequest = new RestRequest(Method.GET);
            restRequest.AddParameter("q", address);
            restRequest.AddParameter("appId", _appId);
            restRequest.AddParameter("flags", "jc"); // J: JSON result, C: Cordinates only.

            var restResponse = restClient.Execute<GeocodeResult>(restRequest);

            // Did this work?
            if (restResponse == null ||
                restResponse.ResponseStatus != ResponseStatus.Completed ||
                restResponse.Data == null ||
                restResponse.Data.ResultSet == null)
            {
                return null;
            }

            // Errors?
            if (restResponse.Data.ResultSet.Error != 0)
            {
                // Yep, error.
                throw new GeocodingServiceException(string.Format("error: {0} : data: {1}",
                                                                  restResponse.Data.ResultSet.ErrorMessage,
                                                                  restResponse.Data));
            }

            // Extract data :)
            return new Location
                   {
                       Latitude = Convert.ToDecimal(restResponse.Data.ResultSet.Results.First().Latitude),
                       Longitude = Convert.ToDecimal(restResponse.Data.ResultSet.Results.First().Longitude)
                   };
        }

        #endregion
    }
}