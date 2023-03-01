using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Location_Info;

public class ViewModel : INotifyPropertyChanged {

  public event PropertyChangedEventHandler? PropertyChanged;

  public void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }

}
