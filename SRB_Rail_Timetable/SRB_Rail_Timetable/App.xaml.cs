using Plugin.Multilingual;
using SRB_Rail_Timetable.Resources;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace SRB_Rail_Timetable
{
    public partial class App : Application
    {
        #region Properties

        // Languages short names
        public const string English_Language = "en";
        public const string Serbian_Language = "sr-Latn-RS";

        /// <summary>
        /// Property name for isSerbian bool.
        /// </summary>
        const string IsSerbianString = "IsSerbian";

        /// <summary>
        /// Is app in serbian language.
        /// </summary>
        public static bool IsSerbian
        {
            get
            {
                if (Current.Properties.ContainsKey(IsSerbianString))
                {
                    return (bool)Current.Properties[IsSerbianString];
                }

                return false;
            }
            set
            {
                Current.Properties[IsSerbianString] = value;
                if (value) // IsSerbian == True
                {
                    SetLanguage(Serbian_Language);
                }
                else // otherwise it is English 
                {
                    SetLanguage(English_Language);
                }
            }
        }

        #endregion

        #region Constructor

        public App()
        {
            InitializeComponent();

            // Set language
            if (IsSerbian) // only change if lang is Serbian => default value is English
            {
                SetLanguage(Serbian_Language);
            }

            // Set main page
            MainPage = new NavigationPage(new MainPage());
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Sets language of application.
        /// </summary>
        public static void SetLanguage(string lang)
        {
            CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo(lang);
            AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;
        }

        #endregion

        #region On Start, Sleep and Resume

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        #endregion
    }
}
