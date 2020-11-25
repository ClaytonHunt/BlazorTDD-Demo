using BlazorTDD.Client.Pages;
using BlazorTDD.Shared;
using BlazorTDD.Tests.Shared;
using Bunit;
using RichardSzalay.MockHttp;
using System;
using System.Linq;
using Xunit;

namespace BlazorTDD.Tests.Unit
{
    public class FetchDataTests : TestContext
    {        
        private MockHttpMessageHandler _http { get; set; }

        public FetchDataTests()
        {
            _http = Services.AddMockHttpClient();
        } 

        [Fact]
        void ItExists()
        {
            // Arrange
            var cut = RenderComponent<FetchData>();

            // Assert
            Assert.NotNull(cut);
        }

        [Fact]
        void Default_IsLoading()
        {
            // Arrange
            var cut = RenderComponent<FetchData>();
            var loading = cut.Find("#loading");

            // Assert
            Assert.Equal("Loading...", loading.InnerHtml);
        }

        [Fact]
        void HttpResponse_RendersForecasts()
        {
            // Arrange
            _http.When("/WeatherForecast").RespondJson(new WeatherForecast[] {
                new WeatherForecast { Date = new DateTime(2020, 11, 25, 15, 47, 0), Summary = "Balmy", TemperatureC = 29 }
            });

            var cut = RenderComponent<FetchData>();

            // Act
            cut.WaitForState(() => cut.FindAll(".forecast").Count > 0);

            // Audit
            var forecasts = cut.FindAll(".forecast");
            var forecast = forecasts.FirstOrDefault();

            // Assert
            Assert.Equal(1, forecasts.Count);
            forecast.MarkupMatches(@"<tr class=""forecast"">
            <td>11/25/2020</td>
            <td>29</td>
            <td>84</td>
            <td>Balmy</td>
        </tr>");
        }
    }
}
