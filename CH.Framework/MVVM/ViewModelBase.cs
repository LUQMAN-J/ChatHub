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

    [ObservableProperty]
    private bool dataLoaded = false;

    [ObservableProperty]
    private bool isErrorState = false;

    [ObservableProperty]
    private string errorMessage = string.Empty;

    [ObservableProperty]
    private string errorImage = string.Empty;

    public ViewModelBase() =>
        IsErrorState = false;

    //Called on Page Appearing
    public virtual async Task OnNavigatedTo(object parameters) =>
        await Task.CompletedTask;

    //Set Loading Indicators for Page
    protected void SetDataLodingIndicators(bool isStaring = true,string text="Loading....")
    {
        if (isStaring)
        {
            IsBusy = true;
            LoadingText = text;
            DataLoaded = false;
            IsErrorState = false;
            ErrorMessage = "";
            ErrorImage = "";
        }
        else
        {
            LoadingText = "";
            IsBusy = false;
        }
    }
}

