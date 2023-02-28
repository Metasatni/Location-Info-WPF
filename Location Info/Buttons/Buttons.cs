using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location_Info.Buttons
{
    abstract class Buttons : ViewModel
    {
        public abstract bool IsEnabled { get; set; }

    }
}
