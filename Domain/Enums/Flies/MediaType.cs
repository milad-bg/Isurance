using System.ComponentModel;

namespace Domain.Enums.Flies
{
    public enum MediaType : byte
    {
        [Description("عکس")]
        Image = 0,

        [Description("فیلم")]
        Video = 1
    }
}
