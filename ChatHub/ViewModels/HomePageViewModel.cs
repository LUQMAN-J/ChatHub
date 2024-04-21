



namespace ChatHub.ViewModels;

public partial class HomePageViewModel : AppViewModelBase
{

    public HomePageViewModel(IApiService appApiService) : base(appApiService)
    {
        SetDataLoadingIndicators();
    }



    [RelayCommand]
    public async Task HomePageButton()
    {

    }
}

