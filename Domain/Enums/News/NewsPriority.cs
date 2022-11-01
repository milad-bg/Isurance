using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Enums.News
{
    public enum NewsPriority : byte
    {
        [Description("کم")]
        Little = 0,

        [Description("متوسط")]
        Normal = 1,

        [Description("زیاد")]
        Much = 2,
    }
}
