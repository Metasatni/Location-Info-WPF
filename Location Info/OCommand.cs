using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Location_Info
{
    class OCommand : ICommand
    {
        public OCommand(Func<object, bool> methodCanExecute, Action<object> methodExecute)
        {
            MethodCanExecute = methodCanExecute;
            MethodExecute = methodExecute;
        }
        Action<object> MethodExecute;
        Func<object, bool> MethodCanExecute;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return MethodExecute != null && MethodCanExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            MethodExecute(parameter);
        }
    }
}
