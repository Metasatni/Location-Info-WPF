using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Location_Info.Buttons
{
    internal class SportButton : Buttons
    {

        private bool _enabled = true;

        public override bool IsEnabled { get => _enabled; set { _enabled = value; OnPropertyChanged(); } }
    }
}
