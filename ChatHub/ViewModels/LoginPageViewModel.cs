

using CH.Framework.Exceptions;
using ChatHub.IServices;
using ChatHub.ViewControl;
using ChatHub.ViewModels.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace ChatHub.ViewModels;

public partial class LoginPageViewModel : AppViewModelBase
{

    public LoginPageViewModel(IApiService appApiService) : base(appApiService)
    {

    }

    [RelayCommand]
    public async Task OnButtonClick()
    {
        App.Current.MainPage = new ShellNavigator();
        // await NavigationService.PushAsync(new HomePage());  
    }

}

