using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Views;
using Google.Android.Material.BottomNavigation;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;

namespace ChatHub.Platforms.Android
{
    internal class CustomShellBottomNavViewAppearanceTracker : ShellBottomNavViewAppearanceTracker
    {
        private readonly IShellContext shellContext;
        private readonly ShellItem shellItem;

        public CustomShellBottomNavViewAppearanceTracker(IShellContext shellContext, ShellItem shellItem) : base(shellContext, shellItem)
        {
            this.shellContext = shellContext;
            this.shellItem = shellItem;
        }
        public override void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
        {
            base.SetAppearance(bottomView, appearance);
            bottomView.LayoutParameters.Height = 280;
            bottomView.SetPadding(30, 30, 30, 30);
            var backgroundDrawable = new GradientDrawable();
            backgroundDrawable.SetShape(ShapeType.Rectangle);
            backgroundDrawable.SetCornerRadius(50);
            backgroundDrawable.SetColor(appearance.EffectiveTabBarBackgroundColor.ToPlatform());
            bottomView.SetBackground(backgroundDrawable);
        }


        private void SetupBottomNavigationView(int id,ShellItem item, BottomNavigationView bottomView)
        {
            int lineMarginFromTop = 15;
            int lineStroke = 15;
            int bottomOffset = bottomView.Height - lineMarginFromTop;
            int itemWidth = bottomView.Width / item.Items.Count;
            int leftOffset = id * itemWidth;
            int rightOffset = itemWidth * (item.Items.Count - (id + 1));
            GradientDrawable topLine = new GradientDrawable();
            topLine.SetShape(ShapeType.Line);
            topLine.SetStroke(lineStroke, Colors.Red.ToAndroid());
            var layerDrawable = new LayerDrawable(new Drawable[] { topLine });
            layerDrawable.SetLayerInset(0, leftOffset, 0, rightOffset, bottomOffset);
            bottomView.SetBackground(layerDrawable);
        }


        protected override void SetBackgroundColor(BottomNavigationView bottomView, Color color)
        {
            base.SetBackgroundColor(bottomView, color);
            bottomView.RootView?.SetBackgroundColor(shellContext.Shell.CurrentPage.BackgroundColor.ToPlatform());
        }
    }
}
