using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUnitTests.Helpers
{
    internal static class MockHTTPMessageHandler
    {
        internal static Mock<HttpMessageHandler> SetupBasicGetResourceList
            (double expectedResponse)
        {
            var mockResponse =
                new HttpResponseMessage(System.Net.HttpStatusCode.OK)
                {
                    Content = new StringContent
                    (JsonConvert.SerializeObject(expectedResponse))
                };
            mockResponse.Content.Headers.ContentType =
             new System.Net.Http.Headers
             .MediaTypeHeaderValue("application/json");

            var handlerMock = new Mock<HttpMessageHandler>();

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponse);

            return handlerMock;
        }

        internal static Mock<HttpMessageHandler> SetupReturn400
        (double expectedResponse)
        {
            var mockResponse =
                new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                {
                    Content = new StringContent
                    (JsonConvert.SerializeObject(expectedResponse))
                };
            mockResponse.Content.Headers.ContentType =
             new System.Net.Http.Headers
             .MediaTypeHeaderValue("application/json");

            var handlerMock = new Mock<HttpMessageHandler>();

            handlerMock.Protected().Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(mockResponse);

            return handlerMock;
        }
    }
}
