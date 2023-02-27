using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Location_Info;

internal class ViewModel : INotifyPropertyChanged {

  public event PropertyChangedEventHandler? PropertyChanged;

  public void OnPropertyChanged([CallerMemberName] string? propertyName = null) {
    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  }

}
