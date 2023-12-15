using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace nowcandid_camera_app
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var app = Application.Current as App;
            reactRootView.ReactNativeHost = app.Host;
        }
    }
}
