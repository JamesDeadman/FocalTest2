using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FocalTest2.ViewModel
{
    public abstract class ViewModelBase : IDisposable, INotifyPropertyChanged
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(string.Empty));
        }

       
    }
}
