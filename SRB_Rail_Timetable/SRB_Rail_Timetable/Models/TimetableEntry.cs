using System;
using System.Collections.Generic;
using System.Text;

using SRB_Rail_Timetable.Logic;

namespace SRB_Rail_Timetable.Models
{
    /// <summary>
    /// Contains data about train line timetable entry (eg. departure, arrival...).
    /// </summary>
    public class TimetableEntry
    {
        public string TrainNumber { get; private set; }

        public DateTime Departure { get; private set; }

        public DateTime Arrival { get; private set; }

        public TimeSpan Late { get; private set; } // 0 minutes if not late

        /// <summary>
        /// Estimated time beetwen station A and B.
        /// </summary>
        public TimeSpan TravelTime { get; private set; }

        public TrainType Type { get; private set; }

        public Tarrifes Tarrifes { get; private set; }

        public TimetableEntry(
            string trainNumber,
            DateTime date,
            string departure,
            string arrival,
            string late,
            string travelTime,
            string trainType,
            List<string> tarrifes)
        {
            // Train Number
            TrainNumber = trainNumber;

            // Departure and Arrival
            Departure = TimetableEntryHelper.MergeDateWithStringTime(date, departure);

            Arrival = TimetableEntryHelper.MergeDateWithStringTime(
                date, arrival,
                TimetableEntryHelper.IsTimeSooner(arrival, departure));

            // Late and Travel Time
            Late = TimetableEntryHelper.ExtractTimeFromString(late);
            TravelTime = TimetableEntryHelper.ExtractTimeFromString(travelTime);

            // Train Type and Tarrife
            Type = TimetableEntryHelper.GetTrainType(trainType);
            Tarrifes = TimetableEntryHelper.GetTarrifes(tarrifes);
        }
    }
}
