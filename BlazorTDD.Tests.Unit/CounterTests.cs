using BlazorTDD.Client.Business;
using BlazorTDD.Client.Pages;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace BlazorTDD.Tests.Unit
{
    public class CounterTests: TestContext
    {
        public CounterTests()
        {
            Services.AddSingleton<SharedState>();
        }

        [Fact]
        public void ItExists()
        {
            // Arrange            
            var cut = RenderComponent<Counter>();

            // Assert
            Assert.NotNull(cut);
        }        

        [Fact]
        public void Default_CountIsZero()
        {
            // Arrange
            var cut = RenderComponent<Counter>();

            var counter = cut.Find("#counter");

            // Assert
            Assert.Equal("Current count: 0", counter.InnerHtml);       
        }

        [Fact]
        public void ButtonClicked_CountIsIncremented()
        {
            // Arrange
            var cut = RenderComponent<Counter>();

            var button = cut.Find("#incrementer");
            var counter = cut.Find("#counter");

            // Act
            button.Click();

            // Assert
            Assert.Equal("Current count: 1", counter.InnerHtml);       
        }

        [Fact]
        public void ButtonClicked_CountIsIncrementedForAll()
        {
            // Arrange
            var counter1 = RenderComponent<Counter>();
            var counter2 = RenderComponent<Counter>();

            var button = counter1.Find("#incrementer");
            var count1 = counter2.Find("#counter");
            var count2 = counter2.Find("#counter");

            // Act
            button.Click();

            // Assert
            Assert.Equal("Current count: 1", count1.InnerHtml);
            Assert.Equal(count1.InnerHtml, count2.InnerHtml);
        }
    }
}
