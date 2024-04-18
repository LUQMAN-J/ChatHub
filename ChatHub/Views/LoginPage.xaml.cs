

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

    private void EventOfVisiblility(object sender, TappedEventArgs e)
    {
        ForgetBox.TranslationX = 50;
        LogInBox.IsVisible = false;
        ForgetBox.IsVisible = true;
        Task.Run(async () =>
        {
            await ViewAnimations.FadeAnimY(ForgetBox);
        });
    }

    private void RevserseVisiblility(object sender, TappedEventArgs e)
    {
        LogInBox.TranslationX = 50;
        ForgetBox.IsVisible = false;
        LogInBox.IsVisible = true;
        Task.Run(async () =>
        {
            await ViewAnimations.FadeAnimY(LogInBox);
        });
    }
}