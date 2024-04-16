

using CH.Framework.Exceptions;
using ChatHub.IServices;
using ChatHub.ViewControl;
using ChatHub.ViewModels.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace ChatHub.ViewModels;

public partial class LoginPageViewModel : AppViewModelBase
{
    [ObservableProperty]
    public string email;
    [ObservableProperty]
    public string password;
    [ObservableProperty]
    public bool isRemember;
   

    public LoginPageViewModel(IApiService appApiService) : base(appApiService)
    {

    }

    [RelayCommand]
    public async Task OnLoginExccution()
    {
        App.Current.MainPage = new ShellNavigator();
    }
    [RelayCommand]
    public async Task OnSignUpExecution()
    {
        await PageService.DisplayAlert("Alert", "Comming Soon", "OK");
        // App.Current.MainPage = new ShellNavigator();
    }
    [RelayCommand]
    public async Task OnForgatPasswordExecution()
    {
        await PageService.DisplayAlert("Alert", "Comming Soon", "OK");
        //App.Current.MainPage = new ShellNavigator();
    }

}

