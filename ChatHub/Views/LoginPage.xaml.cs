

using Microsoft.Maui.Controls;

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

        Task.Run(async () =>
        {
            await ViewAnimations.FadeAnimY(stbox);
            await ViewAnimations.FadeAnimY(signin);
            await ViewAnimations.FadeAnimY(signup);
        });


    }

}