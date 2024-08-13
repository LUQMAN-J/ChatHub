using ChatHub.Models;

namespace ChatHub.Views;

public partial class BaseMapPage : ViewBase<BaseMapViewModel>
{
	public BaseMapPage()
	{
		InitializeComponent();
	}

    private void onItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var Selection = e.SelectedItem as Suggestions;
		if (Selection != null)
		{
			txtSearchQuery.Text = Selection.Name;
			SuggestionListView.IsVisible = false;
            (BindingContext as BaseMapViewModel).SelectedItem = Selection;
		}
    }
}