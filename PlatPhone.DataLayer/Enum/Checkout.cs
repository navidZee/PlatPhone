using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatPhone.DataLayer.Enum
{

    public enum Checkout
    {
        [Description("تسویه شده")]
        ok,
        [Description("عدم تسویه")]
        nok
    }
}

