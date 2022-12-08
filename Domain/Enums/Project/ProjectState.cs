using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.Enums.Project
{
    public enum ProjectState
    {
        [Description("پروژه های تکمیل شده")]
        Done,
        [Description("پروژه های نیمه کاره")]
        HalfDone
    }
}
