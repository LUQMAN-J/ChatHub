

using CoreAnimation;
using CoreGraphics;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility.Platform.iOS;
using Microsoft.Maui.Controls.Platform.Compatibility;
using Microsoft.Maui.Graphics.Platform;
using Microsoft.Maui.Platform;
using UIKit;
using static UIKit.UITabBarItem;


namespace ChatHub.Platforms.iOS
{
    internal class CustomShellTabBarAppearanceTracker : ShellTabBarAppearanceTracker
    {
        public override void UpdateLayout(UITabBarController controller)
        {
            //foreach (var tabbarItem in controller.TabBar.Items)
            //{
            //    var prevImage = tabbarItem.SetAccessibilityLabel;//.Copy() as UIImage;
            //    //var size = new CGSize(24, 24);
            //    //UIGraphics.BeginImageContextWithOptions(size, false, 0);
            //    //prevImage.Draw(new CGRect(new CGPoint(0, 0), size));
            //    //var resizedImage = UIGraphics.GetImageFromCurrentImageContext();
            //    //UIGraphics.EndImageContext();
            //    //tabbarItem.Image = resizedImage;
            //}
            base.UpdateLayout(controller);
            var tabBar = controller.TabBar;
            int tabBarHeight = 70;
            controller.TabBar.Frame = new CGRect(tabBar.Frame.X, tabBar.Frame.Y + (tabBar.Frame.Height - tabBarHeight), tabBar.Frame.Width, tabBarHeight);
            const int cornerRadius = 30;
            var uIBezierPath = UIBezierPath.FromRoundedRect(controller.TabBar.Bounds, UIRectCorner.AllCorners, new CoreGraphics.CGSize(cornerRadius, cornerRadius));
            var cAShapeLayer = new CAShapeLayer
            {
                Frame = controller.TabBar.Bounds,

                Path = uIBezierPath.CGPath
            };
            controller.TabBar.Layer.Mask = cAShapeLayer;
            //UITabBarAppearance tabBarAppearance = (UITabBarAppearance)controller.TabBar.StandardAppearance.Copy();
            //tabBarAppearance.SelectionIndicatorImage= GetImageWithColorPosition(Color.FromHex("D03446").ToUIColor(), new CGSize(UIScreen.MainScreen.Bounds.Width / tabBarHeight, controller.TabBar.Bounds.Size.Height + 4), new CGSize(UIScreen.MainScreen.Bounds.Width / tabBarHeight, 4));
            //UITabBarItemAppearance itemAppearance = new UITabBarItemAppearance();
            ////itemAppearance.Selected.WeakTitleTextAttributes
            ////itemAppearance.Normal.TitleTextAttributes = new UIStringAttributes
            ////{
            ////    Font = UIFont.FromName("Italic", 16),
            ////    BackgroundColor = UIColor.White
            ////    // Font = UIFont.FromName("Arial Bold Italic", 16)//you can set other fonts.

            ////};
            //itemAppearance.Selected.TitleTextAttributes = new UIStringAttributes
            //{
            //    Font = UIFont.FromName("Bold", 16),
            //    BackgroundColor = UIColor.White,
            //};// selected style, you can set selected title color/font.
            //tabBarAppearance.StackedLayoutAppearance = itemAppearance;
            //controller.TabBar.StandardAppearance = tabBarAppearance;
        }
        UIImage GetImageWithColorPosition(UIColor color, CGSize size, CGSize lineSize)
        {
            var renderer = new UIGraphicsImageRenderer(size, new UIGraphicsImageRendererFormat());
            var image = renderer.CreateImage(imageContext =>
            {
                var cgcontext = imageContext.CGContext;
                var rect = new CGRect(0, 0, size.Width, size.Height);
                var rectLine = new CGRect(0, size.Height - lineSize.Height, lineSize.Width, lineSize.Height);
                UIColor.Clear.SetFill();
                UIGraphics.RectFill(rect);
                color.SetFill();
                UIGraphics.RectFill(rectLine);
            });
            return image;
        }

    }

}
