using SRB_Rail_Timetable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SRB_Rail_Timetable.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimetablePage : ContentPage
	{
		public TimetablePage (string title, List<TimetableEntry> items)
		{
			InitializeComponent ();

            Title = title;
            timetableListView.ItemsSource = items;
		}
	}
}