

namespace ChatHub;
public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        //AAPTxy8BH1VEsoebNVZXo8HurHH1LfTKsrSLaKblX0J5EcEspywKBV41nbTr9bZ2YExzTyKBMgAeyJWM7y95-ZUVbVprZutIWifY6Nc3fOkXzhC4liMrqD54lp3JBRR8tn3J2-KbDM7_c9YNx_YK_ezT7xQlTeFCGhYVq2SfWJxQGqCmKm1uLGRdIdibQbjA3-D1m5a_xfkEI9ebY0Y5LrxdP_KCsbLVz61oZnI4vlo317o.AT1_ycUaY7Qt
        //MainPage =new NavigationPage(new FindStore());
        MainPage = new ShellNavigator();
        Shell.Current.GoToAsync("///FindStore");
    }
}
