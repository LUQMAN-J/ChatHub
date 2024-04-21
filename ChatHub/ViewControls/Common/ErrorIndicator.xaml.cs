using Mopups.Pages;
using Mopups.Services;
using SkiaSharp.Extended.UI.Controls;

namespace ChatHub.ViewControls.Common;

public partial class ErrorIndicator : PopupPage
{
    //Bindable Properties

    public static readonly BindableProperty HeaderTitleProperty = BindableProperty.Create(
        "HeaderTitle",
        typeof(string),
        typeof(ErrorIndicator),
        null,
        BindingMode.OneWay,
        null,
        SetHeaderTitle);

    public string HeaderTitle
    {
        get => (string)this.GetValue(HeaderTitleProperty);
        set => this.SetValue(HeaderTitleProperty, value);
    }

    private static void SetHeaderTitle(BindableObject bindable, object oldValue, object newValue) =>
        (bindable as ErrorIndicator).lblheadertitle.Text =$"Uh-Oh! {newValue.ToString()}";


    public static readonly BindableProperty ErrorTextProperty = BindableProperty.Create(
        "ErrorText",
        typeof(string),
        typeof(ErrorIndicator),
        string.Empty,
        BindingMode.OneWay,
        null,
        SetErrorText);

    public string ErrorText
    {
        get => (string)this.GetValue(ErrorTextProperty);
        set => this.SetValue(ErrorTextProperty, value);
    }

    private static void SetErrorText(BindableObject bindable, object oldValue, object newValue) =>
        (bindable as ErrorIndicator).lblErrorText.Text = (string)newValue;


    public static readonly BindableProperty ErrorImageProperty = BindableProperty.Create(
        "ErrorImage",
        typeof(string),
        typeof(ErrorIndicator),
        null,
        BindingMode.OneWay,
        null,
        SetErrorImage);

    public string ErrorImage
    {
        get => (string)this.GetValue(ErrorImageProperty);
        set => this.SetValue(ErrorImageProperty, value);
    }

    private static void SetErrorImage(BindableObject bindable, object oldValue, object newValue)
    {
        (bindable as ErrorIndicator).imgError.Source = (SKLottieImageSource)SKLottieImageSource.FromFile((string)newValue);

    }
        


    public ErrorIndicator()
	{
		InitializeComponent();
	}


    private async void OnBackGroundClick(object sender, TappedEventArgs e)
    {
        await MopupService.Instance.PopAsync(true);
    }
}
