

using CH.Framework.Exceptions;
using ChatHub.IServices;
using ChatHub.ViewControl;
using ChatHub.ViewControls.Common;
using ChatHub.ViewModels.Base;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mopups.Services;


namespace ChatHub.ViewModels;

public partial class LoginPageViewModel : AppViewModelBase
{
    [ObservableProperty]
    public string email;
    [ObservableProperty]
    public string password;
    [ObservableProperty]
    public bool isRemember;
    [ObservableProperty]
    public string forgetEmail;


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
        try
        {
            SetDataLoadingIndicators();
            await Task.Delay(5000);
           // await this.NavigationService.PushAsync(new RegisterPage());
        }
        catch (InternetConnectionException)
        {
            var exception = AppConstants.FromInternet();
            await MopupService.Instance.PushAsync(new ErrorIndicator() { HeaderTitle = "Internet Failure.", ErrorText = exception.Msg, ErrorImage = exception.img });
        }
        catch (Exception ex)
        {
            var exception = AppConstants.FromException(ex.Message);
            await MopupService.Instance.PushAsync(new ErrorIndicator() { HeaderTitle = "Something went wrong.", ErrorText = exception.Msg, ErrorImage = exception.img });
        }
        finally
        {
            SetDataLoadingIndicators(false);
        } 
    }
    [RelayCommand]
    public async Task OnForgatPasswordExecution()
    {
        await PageService.DisplayAlert("Alert", "Comming Soon", "OK");
        //App.Current.MainPage = new ShellNavigator();
    }

}

