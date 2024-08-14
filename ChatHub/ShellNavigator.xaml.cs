namespace ChatHub;

public partial class ShellNavigator : Shell
{
	public ShellNavigator()
	{
		InitializeComponent();
        Routing.RegisterRoute("FindStore", typeof(FindStore));
        Routing.RegisterRoute("HomeNav", typeof(HomePage));
        Routing.RegisterRoute("ChatNav", typeof(ChatPage));
    }
}