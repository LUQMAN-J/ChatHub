

namespace ChatHub.Views;

public partial class LoginPage : ViewBase<LoginPageViewModel>
{
	public LoginPage()
	{
		InitializeComponent();
	}
    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
    }
    protected override  void OnAppearing()
    {
        base.OnAppearing();

        //Task.Run(async () =>
        //{
        //    await Task.Delay(200);
        //    await ViewAnimations.FadeAnimY(Scroller);
        //    await ViewAnimations.FadeAnimY(Stacker);
        //});
    }

}