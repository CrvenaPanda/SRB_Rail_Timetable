using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SRB_Rail_Timetable.Logic;
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
	public partial class StationChooserPopupPage : PopupPage
	{
        Label stationLabel;

		public StationChooserPopupPage (Label stationLabel)
		{
			InitializeComponent ();

            this.stationLabel = stationLabel;
            listView.ItemsSource = TimetableEntryHelper.StationsAndIds.Keys;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Focus on search bar
            searchBar.Focus();
        }


        void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Reset if search box is empty
            if (String.IsNullOrWhiteSpace(e.NewTextValue))
            {
                listView.ItemsSource = TimetableEntryHelper.StationsAndIds.Keys;
            }

            // Filter results
            listView.ItemsSource = TimetableEntryHelper.StationsAndIds.Keys
                .Where(value => value.Contains(e.NewTextValue.ToUpper()));
        }

        async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                listView.SelectedItem = null;
                stationLabel.Text = (string)e.SelectedItem;
                await PopupNavigation.Instance.PopAsync();
            }
        }
    }
}