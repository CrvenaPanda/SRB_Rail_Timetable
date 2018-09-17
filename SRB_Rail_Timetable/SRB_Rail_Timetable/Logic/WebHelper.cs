using System;
using System.Collections.Generic;

using HtmlAgilityPack;
using SRB_Rail_Timetable.Models;

namespace SRB_Rail_Timetable.Logic
{
    /// <summary>
    /// Used for getting data from web.
    /// </summary>
    public static class WebHelper
    {
        #region Indexes for column for certain data

        const int TrainNumberColIndex = 0;
        const int DepartureTimeColIndex = 1;
        const int ArrivalTimeColIndex = 3;
        const int LateColIndex = 5;
        const int TravelTimeColIndex = 6;
        const int TrainTypeColIndex = 7;
        const int TarrifesColIndex = 8;
        const int NoteColIndex = 9;

        #endregion

        #region Methods

        /// <summary>
        /// Generate url to timetable based on starting and ending station, and time.
        /// </summary>
        public static string GenerateTimetableUrl(Station start, Station end, DateTime dateTime)
        {
            var startName = start.Name.Replace(" ", "%20");
            var endName = end.Name.Replace(" ", "%20");

            return String.Format("w3.srbrail.rs/ZSRedVoznje/direktni/{0}/{1}/{2}/{3}/{4}/{5}/en",
                startName,
                start.Id,
                endName,
                end.Id,
                dateTime.ToString("dd.MM.yyyy"),
                dateTime.ToString("HHmm"));
        }

        /// <summary>
        /// Get timetable from web page. Timetable is empty if there is no possible routes.
        /// </summary>
        static List<TimetableEntry> ScrapTrainsTimetable(string pageURL)
        {
            var className = "tabela";
            var timetable = new List<TimetableEntry>();

            // Load Page // TODO: check validity of url
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(pageURL);

            // Find table // TODO: check if there is this node
            var tableNode =
              document.DocumentNode.SelectSingleNode("//table[@class='" + className + "']");

            // Get rows
            var rows = tableNode.SelectNodes("tr");

            // Iterate through rows
            for (int i = 1; i < rows.Count; i += 2) // i = 1 to skip header and we increase by 2 to skip doubles (this is how website works)
            {
                // Get columns
                var columns = rows[i].SelectNodes("th|td");


                // Get Data (column indexes are based on website)
                string trainNumber = columns[TrainNumberColIndex].InnerText.Trim();
                string departureTime = columns[DepartureTimeColIndex].InnerText.Trim();
                string arrivalTime = columns[ArrivalTimeColIndex].InnerText.Trim();
                string late = columns[LateColIndex].InnerText.Trim();
                string travelTime = columns[TravelTimeColIndex].InnerText.Trim();
                string trainType = columns[TrainTypeColIndex].ChildNodes[1].GetAttributeValue("title", "no title attr"); // Using second child node (thats how is it stored on web site)

                var tarrifes = new List<String>();
                foreach (var child in columns[TarrifesColIndex].ChildNodes)
                {
                    string attr = child.GetAttributeValue("title", "no");

                    if (attr != "no")
                    {
                        tarrifes.Add(attr);
                    }
                }

                string note = columns[NoteColIndex].InnerText.Trim();

                // Add data to list

            }

            return timetable;
        }

        #endregion
    }
}
