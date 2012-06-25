using WorldDomination.GeocodingServices.Services.Yahoo;
using Xunit;

namespace WorldDomination.GeocodingServices.IntegrationTests
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

                var geocodingService = new GeocodingService(appId);

                // Act.
                var result = geocodingService.Geocode(address);

                // Asserts.
                Assert.NotNull(result);
                Assert.Equal(38.898717m, result.Latitude);
                Assert.Equal(-77.035974m, result.Longitude);
            }
        }
    }

    // ReSharper restore InconsistentNaming
}