using System.Text;
using Moq;
using RestSharp;
using WorldDomination.GeocodingServices.Services.Yahoo;

namespace WorldDomination.GeocodingServices.Tests
{
    public static class MockHelpers
    {
        public static IRestClient MockRestClient(GeocodeResult geocodeResult)
        {
            return MockRestClient(geocodeResult, ResponseStatus.Completed, null);
        }

        //public static IRestClient MockRestClient(ResponseStatus responseStatus, string content)
        //{
        //    return MockRestClient(null, responseStatus, content);
        //}

        public static IRestClient MockRestClient(GeocodeResult geocodeResult, ResponseStatus responseStatus,
                                                 string content)
        {
            // NOTE: geocodeResult Or content can be nullable.

            var mockRestClient = new Mock<IRestClient>();
            mockRestClient
                .Setup(x => x.Execute<GeocodeResult>(It.IsAny<IRestRequest>()))
                .Returns(new RestResponse<GeocodeResult>
                         {
                             ResponseStatus = responseStatus,
                             Data = geocodeResult,
                             RawBytes = string.IsNullOrEmpty(content) ? null : Encoding.UTF8.GetBytes(content)
                         });

            return mockRestClient.Object;
        }
    }
}