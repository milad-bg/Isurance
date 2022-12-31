using System.ComponentModel;

namespace Domain.Enums.Tenders
{
    public enum Product_Or_Service_Production_line : byte
    {
        [Description("تاسیسات برقی")]
        Electrical_Installations = 1,

        [Description("تاسیسات مکانیکی  ")]
        Mechanical = 2,

        [Description("ابینه ")]
        Abina = 3,

        [Description("نازکئکاری و تزیینات  ")]
        Joinery_And_Decorations = 4,

        [Description("تاسیسات برقی خاص  ")]
        Special_Electrical_Installations = 5,

        [Description("تجهیزات پزشکی  ")]
        Medical_Equipment = 6,

        [Description("مصالح ساختمانی ")]
        Building_Materials = 7,

        [Description("پیمانکار ساختمانی  ")]
        Construction_Contractor = 8,

        [Description("پیمانکاران تخصصی  ")]
        Specialized_contractors = 9,

        [Description("مشاور ")]
        Consultant = 10,
    }
}
