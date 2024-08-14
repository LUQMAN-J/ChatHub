

namespace ChatHub;
public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new ShellNavigator();
        Shell.Current.GoToAsync("BaseMapRoute");
        // MainPage =new NavigationPage(new LoginPage());// new ShellNavigator();
    }
}
