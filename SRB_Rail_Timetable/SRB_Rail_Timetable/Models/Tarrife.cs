using System;

namespace SRB_Rail_Timetable.Models
{
    [Flags]
    public enum Tarrifes
    {
        FirstClass = 1,
        SecondClass = 2,
        Coushete = 4,
        ObligatoryReservation = 8,
        Bicycle = 16
    }
}
