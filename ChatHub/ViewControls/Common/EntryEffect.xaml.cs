
namespace ChatHub.ViewControls.Common;

public partial class EntryEffect
{
    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public string HintText
    {
        get => (string)GetValue(HintTextProperty);
        set => SetValue(HintTextProperty, value);
    }
    public static readonly BindableProperty TitleProperty
            = BindableProperty.Create(
                nameof(Title),
                typeof(string),
                typeof(EntryEffect));

    public static readonly BindableProperty TextProperty
        = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(EntryEffect),
            defaultBindingMode: BindingMode.TwoWay);

    public static readonly BindableProperty TextColorProperty
        = BindableProperty.Create(
            nameof(TextColor),
            typeof(Color),
            typeof(EntryEffect),
            defaultBindingMode: BindingMode.TwoWay,
            defaultValue: Colors.White);

    public static readonly BindableProperty HintTextProperty
        = BindableProperty.Create(
            nameof(HintText),
            typeof(string),
            typeof(EntryEffect),
            defaultBindingMode: BindingMode.TwoWay);
    public EntryEffect()
    {
        InitializeComponent();
    }

}