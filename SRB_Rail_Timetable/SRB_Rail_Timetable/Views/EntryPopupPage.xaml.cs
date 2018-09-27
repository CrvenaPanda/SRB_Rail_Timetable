using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SRB_Rail_Timetable.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SRB_Rail_Timetable.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EntryPopupPage : PopupPage
	{
		public EntryPopupPage (TimetableEntry entry, string destinationTitle)
		{
            if (entry == null)
            {
                PopupNavigation.Instance.PopAsync();
                return;
            }

			InitializeComponent ();

            // Set data
            titleLabel.Text = destinationTitle;
            SetEntryData(entry);
            SetTarrifes(entry.Tarrifes);
            SetNote(entry.Note);
		}

        void SetNote(string note)
        {
            if (note.Length > 0)
            {
                noteLabel.Text = "* " + note;
            }
        }

        void SetTarrifes(Tarrifes tarrifes)
        {
            if (tarrifes.HasFlag(Tarrifes.FirstClass))
            {
                tarrifesLayout.Children.Add(new Label { Text = "FIRST CLASS" });
            }
            if (tarrifes.HasFlag(Tarrifes.SecondClass))
            {
                tarrifesLayout.Children.Add(new Label { Text = "SECOND CLASS" });
            }
            if (tarrifes.HasFlag(Tarrifes.Coushete))
            {
                tarrifesLayout.Children.Add(new Label { Text = "COUSHETE" });
            }
            if (tarrifes.HasFlag(Tarrifes.ObligatoryReservation))
            {
                tarrifesLayout.Children.Add(new Label { Text = "OBLIGATORY RESERVATION" });
            }
            if (tarrifes.HasFlag(Tarrifes.Bicycle))
            {
                tarrifesLayout.Children.Add(new Label { Text = "BICYCLE" });
            }
        }

        void SetEntryData(TimetableEntry entry)
        {
            dateLabel.Text = entry.Departure.ToString("d MMM, yyyy");
            trainLabel.Text = GetTrainTypeAndNumber(entry);
            timeLabel.Text = "TIME:  " + entry.Departure.ToString("hh\\:mm - ") + entry.Arrival.ToString("hh\\:mm");
            lateLabel.Text = "LATE:  " + entry.Late.ToString("hh\\:mm");
            travelLabel.Text = "TRAVEL:  " + entry.TravelTime.ToString("hh\\:mm");
        }

        string GetTrainTypeAndNumber(TimetableEntry trainEntry)
        {
            string result;
            
            // Set train type
            switch (trainEntry.Type)
            {
                case TrainType.FastTrain: result = "FAST TRAIN"; break;
                case TrainType.InterCity: result = "INTER CITY"; break;
                case TrainType.RegioVoz: result = "REGIO VOZ"; break;
                default: result = "LOCAL"; break;
            }

            // Set train number
            result += (" " + trainEntry.TrainNumber);

            return result;
        }

        protected override bool OnBackButtonPressed()
        {
            PopupNavigation.Instance.PopAsync();
            return true;
        }
    }
}