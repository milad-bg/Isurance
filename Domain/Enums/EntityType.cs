using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Enums
{
    public enum EntityType
    {
        [Description("اخبار")]
        NewsCast = 1000
    }
}
