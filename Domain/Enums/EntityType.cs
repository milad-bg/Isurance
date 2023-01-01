using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Enums
{
    public enum EntityType
    {
        [Description("اخبار")]
        NewsCast = 1000,

        [Description("پروژه")]
        Project = 1001,

       [Description("شخص")]
        Person = 1002
    }
}
