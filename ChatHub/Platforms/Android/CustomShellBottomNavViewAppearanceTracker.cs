
using Android.Graphics;
using Android.Graphics.Drawables;
using Google.Android.Material.BottomNavigation;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Platform;
using Paint = Android.Graphics.Paint;
using Color = Android.Graphics.Color;
using Path = Android.Graphics.Path;

namespace ChatHub.Platforms.Android
{
    internal class CustomShellBottomNavViewAppearanceTracker : ShellBottomNavViewAppearanceTracker
    {
        private readonly IShellContext shellContext;
        private readonly ShellItem shellItem;
        private Color SelectedColor { get; set; }
        public CustomShellBottomNavViewAppearanceTracker(IShellContext shellContext, ShellItem shellItem) : base(shellContext, shellItem)
        {
            this.shellContext = shellContext;
            this.shellItem = shellItem;
        }

        public override void SetAppearance(BottomNavigationView bottomView, IShellAppearanceElement appearance)
        {

            base.SetAppearance(bottomView, appearance);
            bottomView.ItemPaddingTop = 60;
            bottomView.LayoutParameters.Height = 260;
            bottomView.SetPadding(10, 10, 10, 10);
            var backgroundDrawable = new GradientDrawable();
            backgroundDrawable.SetShape(ShapeType.Rectangle);
            backgroundDrawable.SetCornerRadius(50);
            SelectedColor = appearance.EffectiveTabBarTitleColor.ToPlatform();
            backgroundDrawable.SetColor(appearance.EffectiveTabBarBackgroundColor.ToPlatform());
            bottomView.SetBackground(backgroundDrawable);
            UpdateIndicator(bottomView);
        }

        public void UpdateIndicator(BottomNavigationView bottomNavView)
        {
            var menuView = bottomNavView.GetChildAt(0) as BottomNavigationMenuView;
            if (menuView != null)
            {
                int id = menuView.SelectedItemId;
                var selectedItemView = menuView.GetChildAt(id) as BottomNavigationItemView;
                if (selectedItemView != null)
                {
                    // Remove previous indicator
                    for (int i = 0; i < menuView.ChildCount; i++)
                    {
                        var item = menuView.GetChildAt(i);
                        if (item is BottomNavigationItemView itemView)
                        {
                            GradientDrawable shapeeDrawable = new GradientDrawable();
                            shapeeDrawable.SetColor(Colors.Transparent.ToAndroid());
                            itemView.SetBackground(shapeeDrawable);
                        }
                    }
                    var indicatorDrawable = new TopIndicatorDrawable(SelectedColor); 
                    selectedItemView.SetBackground(indicatorDrawable);
                }
            }
        }


        public class TopIndicatorDrawable : Drawable
        {
            private readonly Paint paint;

            public TopIndicatorDrawable(Color color)
            {
                paint = new Paint
                {
                    Color = color,
                    AntiAlias = true
                };
            }

            public override void Draw(Canvas canvas)
            {
                var bounds = Bounds;
                //var lineHeight = 15; // Adjust line height
                //canvas.DrawRect(bounds.Left, 0, bounds.Right, bounds.Top + lineHeight, paint);


                var triangleHeight = bounds.Height() / 7; // Set the height of the triangle
                var triangleWidth = bounds.Width(); // triangleHeight * 4; // Set the base width of the triangle
                var path = new Path();
                path.MoveTo(bounds.CenterX() - (triangleWidth / 2), 0); // Start from the top-left corner of the triangle
                path.LineTo(bounds.CenterX() + (triangleWidth / 2), 0); // Draw a line to the top-right corner of the triangle
                path.LineTo(bounds.CenterX(), triangleHeight); // Draw a line to the bottom center of the triangle
                path.Close(); // Close the path to form a triangle
                canvas.DrawPath(path, paint);
            }

            public override void SetAlpha(int alpha)
            {
                paint.Alpha = alpha;
            }

            public override void SetColorFilter(ColorFilter? colorFilter)
            {
                paint.SetColorFilter(colorFilter);
            }

            public override int Opacity => (int)Format.Transparent;
        }



        //protected override void SetBackgroundColor(BottomNavigationView bottomView, Color color)
        //{
        //    base.SetBackgroundColor(bottomView, color);
        //    bottomView.RootView?.SetBackgroundColor(shellContext.Shell.CurrentPage.BackgroundColor.ToPlatform());
        //}
    }
}
