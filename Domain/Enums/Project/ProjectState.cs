using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.Enums.Project
{
    public enum ProjectState : byte
    {
        [Description("پروژه های تکمیل شده")]
        Done = 1,
        [Description("پروژه های نیمه کاره")]
        HalfDone = 2
    }



    public enum ProjectType : byte
    {
        [Description("نظارت")]
        Supervision = 1,
        [Description("اجرا")]
        Performance = 2
    }
}

