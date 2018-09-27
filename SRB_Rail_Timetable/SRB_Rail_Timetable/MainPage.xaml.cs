using SRB_Rail_Timetable.Logic;
using SRB_Rail_Timetable.Models;
using SRB_Rail_Timetable.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            var URL = GenerateURL();

            // Get timetable
            var timetable = WebHelper.ScrapTrainsTimetable(URL, datePicker.Date);

            // Create timetable page
            Navigation.PushAsync(new TimetablePage($"{fromEntry.Text} - {toEntry.Text}" , timetable));
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
