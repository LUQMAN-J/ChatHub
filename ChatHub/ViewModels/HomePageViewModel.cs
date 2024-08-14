



using ChatHub.ViewControls.Common;

namespace ChatHub.ViewModels;

public partial class HomePageViewModel : AppViewModelBase
{

    public HomePageViewModel(IApiService appApiService) : base(appApiService)
    {

    }



    [RelayCommand]
    public async Task HomePageButton()
    {
        //var sheet = new OnBottomSheet(await _appApiService.getStores());
        // await sheet.ShowAsync();

    }
}

