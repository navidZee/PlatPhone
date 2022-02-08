using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatPhone.DataLayer.Enum
{
    public enum Confirmation
    {
        [Description("در انتظار تایید")]
        Waiting,
        [Description("تایید شده")]
        Accepted,
        [Description("رد شده")]
        Rejectd        
    }
}
