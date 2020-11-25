using System.ComponentModel;

namespace BlazorTDD.Client.Business
{
    public class SharedState : INotifyPropertyChanged
    {
        private int count;

        public event PropertyChangedEventHandler PropertyChanged;
        
        public int Count { 
            get => count; 
            private set {
                count = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            }
        }

        public void Increment()
        {
            Count++;
        }
    }
}
