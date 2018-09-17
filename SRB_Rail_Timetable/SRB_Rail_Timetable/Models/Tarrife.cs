using System;

namespace SRB_Rail_Timetable.Models
{
    [Flags]
    public enum Tarrife
    {
        FirstClass = 0x0,
        SecondClass = 0x1,
        Coushete = 0x2,
        ObligatoryReservation = 0x4,
        Bicycle = 0x8
    }
}
