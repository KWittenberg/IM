using System.ComponentModel;

namespace IM.Models.Dto;

public enum BookBinding
{
    Tvrdi = 1,
    Meki = 2,
    [Description("Meki s klapnama")]
    MekiSKlapnama = 3
}