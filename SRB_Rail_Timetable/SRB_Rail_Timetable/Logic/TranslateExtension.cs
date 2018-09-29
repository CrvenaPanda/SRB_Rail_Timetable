using Plugin.Multilingual;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SRB_Rail_Timetable.Logic
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        const string ResourceId = "SRB_Rail_Timetable.Resources.AppResources";

        static readonly Lazy<ResourceManager> resmgr =
            new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider = null) // serviceProvider is null when we call this method from code and not XAML
        {
            if (Text == null)
            {
                return String.Empty;
            }

            // Get culture info and translation
            var cultureInfo = CrossMultilingual.Current.CurrentCultureInfo;
            var translation = resmgr.Value.GetString(Text, cultureInfo);

            // If translation is not found
            // return key of translation string
            if (translation == null)
            {
                translation = Text;
            }

            return translation;
        }
    }
}
