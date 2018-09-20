using SRB_Rail_Timetable.Logic;
using SRB_Rail_Timetable.Models;
using SRB_Rail_Timetable.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SRB_Rail_Timetable
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        void Search_Clicked(object sender, EventArgs e)
        {
            // Get URL
            //var URL = GenerateURL();

            // Get timetable TODO:
            //var timetable = WebHelper.ScrapTrainsTimetable(URL);

            var test = new List<TimetableEntry>() // TODO: Remove me
            {
                new TimetableEntry("123", DateTime.Now.Date, "5:25", "7:00", "", "1:35", "FAST TRAIN", new List<string>(){ "First class"}, ""),
                new TimetableEntry("123", DateTime.Now.Date, "10:25", "12:00", "", "1:35", "FAST TRAIN", new List<string>(){ "First class"}, ""),
                new TimetableEntry("123", DateTime.Now.Date, "15:25", "17:00", "", "1:35", "FAST TRAIN", new List<string>(){ "First class"}, "")
            };

            // TODO: Create timetable page
            Navigation.PushAsync(new TimetablePage($"{fromEntry.Text} - {toEntry.Text}" , test));
        }

        /// <summary>
        /// Generates web page url based on user data.
        /// </summary>
        string GenerateURL()
        {
            // Get URL
            var URL = WebHelper.GenerateTimetableUrl
                (
                fromEntry.Text, TimetableEntryHelper.StationsAndIds[fromEntry.Text],
                toEntry.Text, TimetableEntryHelper.StationsAndIds[toEntry.Text],
                new DateTime
                    (
                        datePicker.Date.Year,
                        datePicker.Date.Month,
                        datePicker.Date.Day,
                        timePicker.Time.Hours,
                        timePicker.Time.Minutes,
                        0
                    )
                );

            return URL;
        }
    }
}
