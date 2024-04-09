



namespace ChatHub.ViewModels;

public partial class HomePageViewModel : AppViewModelBase
{

    public HomePageViewModel(IApiService appApiService) : base(appApiService)
    {
      
    }



    [RelayCommand]
    public async Task HomePageButton()
    {

    }
}

