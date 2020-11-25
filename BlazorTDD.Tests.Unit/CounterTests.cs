using BlazorTDD.Client.Pages;
using Bunit;
using Xunit;

namespace BlazorTDD.Tests.Unit
{
    public class CounterTests
    {
        [Fact]
        public void ItExists()
        {
            // Arrange
            var ctx = new TestContext();
            var cut = ctx.RenderComponent<Counter>();

            // Assert
            Assert.NotNull(cut);
        }        

        [Fact]
        public void Default_CountIsZero()
        {
            // Arrange
            var ctx = new TestContext();
            var cut = ctx.RenderComponent<Counter>();

            var counter = cut.Find("#counter");

            // Assert
            Assert.Equal("Current count: 0", counter.InnerHtml);       
        }

        [Fact]
        public void ButtonClicked_CountIsIncremented()
        {
            // Arrange
            var ctx = new TestContext();
            var cut = ctx.RenderComponent<Counter>();

            var button = cut.Find("#incrementer");
            var counter = cut.Find("#counter");

            // Act
            button.Click();

            // Assert
            Assert.Equal("Current count: 1", counter.InnerHtml);       
        }
    }
}
