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
	public partial class AboutPage : ContentPage
	{
        #region Constructor

        public AboutPage ()
		{
			InitializeComponent ();
		}

        #endregion

        #region Tapped Events

        /// <summary>
        /// Send mail to developer.
        /// </summary>
        void MailDeveloper_Tapped(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(@"https://mailto:some_mail_address@gmail.com")); // TODO: Add Mail
        }

        #endregion
    }
}