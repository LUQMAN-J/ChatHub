using Microsoft.Maui.Controls;
using System.Drawing;

namespace ChatHub.Views;

public partial class HomePage : ViewBase<HomePageViewModel>
{
    private bool isCollapsed = true;
    private const uint AnimationDuration = 500;
    private const double ExpandedWidth = 200; // Adjust as needed
    private const double CollapsedWidth = 0; // Adjust as needed // Adjust as needed
    public HomePage()
	{
		InitializeComponent();
	}

    private void OnToggleButtonClicked(object sender, EventArgs e)
    {
        if (isCollapsed)
        {
            ExpandEntry();
        }
        else
        {
            CollapseEntry();
        }
        isCollapsed = !isCollapsed;
    }

    private void ExpandEntry()
    {
        var expandAnimation = new Animation(v => AnimatedEntry.WidthRequest = v, AnimatedEntry.WidthRequest, ExpandedWidth);
        expandAnimation.Commit(this, "ExpandEntry", length: AnimationDuration, easing: Easing.Linear);
    }

    private void CollapseEntry()
    {
        var collapseAnimation = new Animation(v => AnimatedEntry.WidthRequest = v, AnimatedEntry.WidthRequest, CollapsedWidth);
        collapseAnimation.Commit(this, "CollapseEntry", length: AnimationDuration, easing: Easing.Linear);
    }
}