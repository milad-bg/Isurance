using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.Enums.Flies
{
    public enum MediaEntityType : byte
    {
        [Description("عکس کاور")]
        CoverImage = 0,

        [Description("عکس")]
        Image = 1,

        [Description("لوگو")]
        logo = 2
    }
}
