using SRB_Rail_Timetable.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SRB_Rail_Timetable.Logic
{
    /// <summary>
    /// Helps with creation of TimetableEntry.
    /// </summary>
    public static class TimetableEntryHelper
    {
        #region Train Type Strings

        const string train_FastTrainString = "FAST TRAIN";
        const string train_RegioVozString = "REGIO VOZ";
        const string train_InterCityString = "INTER CITY";

        #endregion


        #region Tarrife Type Strings

        const string tarr_FirstClassString = "First class";
        const string tarr_SecondClassString = "Second class";
        const string tarr_ObligatoryReservationString = "Obligatory reservation";
        const string tarr_BicycleString = "Bicikla";
        const string tarr_CousheteString = "Coushete";

        #endregion


        #region Public Methods

        /// <summary>
        /// Checks if time is sooner than other one. Format: (HH:mm).
        /// </summary>
        /// <returns>True if time is sooner, else False.</returns>
        public static bool IsTimeSooner(string time, string comparedToTime)
        {
            // Get values
            var values1 = time.Split(':');
            var values2 = comparedToTime.Split(':');

            double hour1 = int.Parse(values1[0]);
            double minutes1 = int.Parse(values1[1]);

            double hour2 = int.Parse(values2[0]);
            double minutes2 = int.Parse(values2[1]);

            // Compare values
            if (hour2 > hour1)
            {
                return true;
            }
            if (values1[0] == values2[0])
            {
                return minutes2 > minutes1;
            }

            return false;
        }

        /// <summary>
        /// Merges date from DateTime with string. Format = (HH:mm)
        /// </summary>
        /// <param name="nextDay">Should we increase day by one?</param>
        public static DateTime MergeDateWithStringTime(DateTime date, string departure, bool nextDay = false)
        {
            var hourAndMinutes = departure.Split(':');

            var result = new DateTime(
                date.Year,
                date.Month,
                date.Day,
                int.Parse(hourAndMinutes[0]),
                int.Parse(hourAndMinutes[1]),
                0);

            if (nextDay)
            {
                return result.AddDays(1);
            }

            return result;
        }

        /// <summary>
        /// Extracts time from string. Format = (HH:mm)
        /// </summary>
        public static TimeSpan ExtractTimeFromString(string value)
        {
            double minutes = 0;

            if (!String.IsNullOrWhiteSpace(value))
            {
                var hourAndMinutes = value.Split(':');

                if (hourAndMinutes[0] != "00")
                {
                    minutes += (double.Parse(hourAndMinutes[0]) * 60); // add hours
                }

                if (hourAndMinutes[1] != "00")
                {
                    minutes += double.Parse(hourAndMinutes[1]); // Add minutes
                }
            }

            return TimeSpan.FromMinutes(minutes);
        }

        /// <summary>
        /// Gets train type from string.
        /// </summary>
        public static TrainType GetTrainType(string value)
        {
            if (value == train_FastTrainString)
            {
                return TrainType.FastTrain;
            }
            if (value == train_RegioVozString)
            {
                return TrainType.RegioVoz;
            }
            if (value == train_InterCityString)
            {
                return TrainType.InterCity;
            }

            return TrainType.Local;
        }

        /// <summary>
        /// Gets tarrifes from list of strings. (Must be atlest one!)
        /// </summary>
        public static Tarrife GetTarrifes(List<string> list)
        {
            // TODO: Make sure you have all possible tarrifes

            if (list == null || list.Count == 0)
            {
                throw new ArgumentException("List must have atleast one element");
            }

            var output = ConvertStringToTarrife(list[0]);

            for (int i = 1; i < list.Count; i++) // i = 0 bacause We already added first element
            {
                output |= ConvertStringToTarrife(list[i]);
            }

            return output;
        }

        #endregion


        #region Internal Methods

        /// <summary>
        /// Converts string to tarrife.
        /// </summary>
        static Tarrife ConvertStringToTarrife(string value)
        {
            // TODO: Make sure you have all possible tarrifes

            switch (value)
            {
                case tarr_BicycleString: return Tarrife.Bicycle;
                case tarr_CousheteString: return Tarrife.Coushete;
                case tarr_FirstClassString: return Tarrife.FirstClass;
                case tarr_ObligatoryReservationString: return Tarrife.ObligatoryReservation;
                case tarr_SecondClassString: return Tarrife.SecondClass;
                default:
                    throw new ArgumentException("value must be one of predefined strings!");
            }
        }

        #endregion
    }
}
