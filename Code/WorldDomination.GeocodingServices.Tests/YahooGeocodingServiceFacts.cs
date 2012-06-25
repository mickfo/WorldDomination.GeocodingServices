using System.Collections.Generic;
using WorldDomination.GeocodingServices.Services.Yahoo;
using Xunit;

namespace WorldDomination.GeocodingServices.Tests
{
    // ReSharper disable InconsistentNaming

    public class YahooGeocodingServiceFacts
    {
        public class GeocodeFacts
        {
            [Fact]
            public void GivenAValidAddress_Geocode_ReturnsALatitudeAndLongitude()
            {
                // Arrange.
                const string address = "1600 Pennsylvania Avenue, Washington, DC";
                const string appId = "goodApiKey";
                var data = new GeocodeResult
                           {
                               ResultSet = new ResultSet
                                           {
                                               Version = "1.0",
                                               Error = 0,
                                               ErrorMessage = "No error",
                                               Locale = "us_US",
                                               Quality = 87,
                                               Found = 1,
                                               Results = new List<Result>
                                                         {
                                                             new Result
                                                             {
                                                                 Quality = 85,
                                                                 Latitude = "38.898717",
                                                                 Longitude = "-77.035974",
                                                                 Offsetlat = "38.898590",
                                                                 Offsetlon = "-77.035971",
                                                                 Radius = 500
                                                             }
                                                         }
                                           }
                           };

                var geocodingService = new GeocodingService(appId, MockHelpers.MockRestClient(data));

                // Act.
                var result = geocodingService.Geocode(address);

                // Asserts.
                Assert.NotNull(result);
                Assert.Equal("38.898717", result.Latitude);
                Assert.Equal("-77.035974", result.Longitude);
            }
        }
    }

    // ReSharper restore InconsistentNaming
}