using BlazorTDD.Client.Business;
using System.ComponentModel;
using Xunit;

namespace BlazorTDD.Tests.Unit
{
    public class SharedStateTests
    {
        private SharedState _state;

        public SharedStateTests()
        {
            _state = new SharedState();
        }

        [Fact]
        public void ItExists()
        {
            // Assert
            Assert.NotNull(_state);
        }

        [Fact]
        public void ItImplementsINotifyProperyChanged()
        {
            // Assert
            Assert.IsAssignableFrom<INotifyPropertyChanged>(_state);
        }

        [Fact]
        public void Default_CountIsZero()
        {
            // Assert
            Assert.Equal(0, _state.Count);
        }

        [Fact]
        public void Increment_CountIsIncreasedByIncrement()
        {
            // Act
            _state.Increment();

            // Assert
            Assert.Equal(1, _state.Count);
        }

        [Fact]
        public void Increment_ListenerIsNotified()
        {
            // Arrange
            var currentCount = 0;

            _state.PropertyChanged += (sender, args) => {
                if(args.PropertyName == nameof(_state.Count))
                {
                    currentCount = _state.Count;
                }
            };

            // Act
            _state.Increment();

            // Assert
            Assert.Equal(1, currentCount);
        }
    }
}
