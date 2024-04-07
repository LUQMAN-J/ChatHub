



namespace ChatHub.ViewModels;

public partial class HomePageViewModel : AppViewModelBase
{
    private readonly HubConnection _connection;
    public HomePageViewModel(IApiService appApiService) : base(appApiService)
    {
        _connection = new HubConnectionBuilder()
               .WithUrl("https://luqmanchathub.azurewebsites.net/chat").WithAutomaticReconnect()
               .Build();
    }

    [ObservableProperty]
    public string message;
    [ObservableProperty]
    public string myMessage;


    //private HubConnection _connection { get; set; }
    public override async Task OnNavigatedTo(object parameters)
    {


        _connection.On<string>("MessageReceived", (message) =>
        {
            Message += Environment.NewLine + message;
        });


        await _connection.StartAsync();

    }

    [RelayCommand]
    public async Task OnButtonClick()
    {
        await _connection.InvokeCoreAsync("SendMessage", args: new[] { MyMessage });

        MyMessage = String.Empty;
    }
}

