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
    }
}
