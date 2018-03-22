//using Form.Resx;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Form.Pages
{
    /// <summary>
    ///     mainPage : display want to search which part
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //測試語系
            //https://developer.xamarin.com/guides/xamarin-forms/application-fundamentals/localization/
            //TestLabel.Text = "Hello" + AppResources.test;
        }
    }
}