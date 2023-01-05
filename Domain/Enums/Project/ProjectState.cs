using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Domain.Enums.Project
{
    public enum ProjectState : byte
    {
        [Description("پیش فرض")]
        defult = 0,
        [Description("پایان یافته")]
        Done = 1,
        [Description("در حال اجرا")]
        Inprocess = 2
    }



    public enum ProjectType : byte
    {
        [Description("پیش فرض")]
        defult = 0,
        [Description("نظارت")]
        Supervision = 1,
        [Description("طراحی")]
        Designing = 2,
        [Description("طراحی و نظارت")]
        DesigningAndSupervision = 3
    }
}

