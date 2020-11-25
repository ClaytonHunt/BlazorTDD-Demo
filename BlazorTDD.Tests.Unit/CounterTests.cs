using BlazorTDD.Client.Pages;
using Bunit;
using Xunit;

namespace BlazorTDD.Tests.Unit
{
    public class CounterTests: TestContext
    {
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
    }
}
