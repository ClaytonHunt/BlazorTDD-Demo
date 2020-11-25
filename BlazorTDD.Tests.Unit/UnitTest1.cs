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
    }
}
