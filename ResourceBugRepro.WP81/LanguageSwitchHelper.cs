using System.Globalization;
using Windows.ApplicationModel.Resources.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ResourceBugRepro.WP81
{
    public static class LanguageSwitchHelper
    {
        public static void ChangeLanguage(string code, FlowDirection flowDirection)
        {
            var culture = new CultureInfo(code);
            Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride = culture.Name;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            var frame = Window.Current.Content as Frame;
            if (frame != null)
                frame.FlowDirection = flowDirection;
            //var loader = new Windows.ApplicationModel.Resources.ResourceLoader();

            ResourceManager.Current.DefaultContext.Reset();
            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().Reset();
            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();
        }
    }
}
