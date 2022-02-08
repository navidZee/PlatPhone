using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatPhone.DataLayer.Enum
{
    public enum RequestLevel
    {
        [Description("درحال ارسال")]
        Sending,
        [Description("اتمام درخواست ")]
        delivered,
        [Description("مرجوئی")]
        Rejectd
    }
}
