using SRB_Rail_Timetable.Logic;
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
                

            // Show results

            // TODO: Create timetable page
        }
    }
}
