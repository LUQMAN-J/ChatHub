using CommunityToolkit.Mvvm.ComponentModel;

namespace CH.Framework.MVVM;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    private string title = string.Empty;

    [ObservableProperty]
    private bool isBusy = false;

    [ObservableProperty]
    private string loadingText = string.Empty;


    //Called on Page Appearing
    public virtual async Task OnNavigatedTo(object parameters) =>
        await Task.CompletedTask;

    //Set Loading Indicators for Page
    protected void SetDataLoadingIndicators(bool isStaring = true,string text="Loading....")
    {
        if (isStaring)
        {
            IsBusy = true;
            LoadingText = text;
        }
        else
        {
            LoadingText = "";
            IsBusy = false;
        }
    }
}

