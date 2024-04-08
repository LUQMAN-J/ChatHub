using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Platform.Compatibility;
using UIKit;
namespace ChatHub.Platforms.iOS
{
    internal class ShellHandler : ShellRenderer
    {
        //protected override IShellItemRenderer CreateShellItemRenderer(ShellItem item)
        //{
        //    var renderer = base.CreateShellItemRenderer(item);
        //    if (renderer != null)
        //    {
        //        if (renderer is ShellItemRenderer shellItem)
        //        {
        //            var items = shellItem.TabBar.Items;
        //            foreach (var i in items)
        //            {
        //                UITabBarItem item_temp = i;
        //                UIView view = item_temp.ValueForKey(new Foundation.NSString("view")) as UIView;
        //                Console.WriteLine("================");
        //                Console.WriteLine(view);
        //              //  UILabel label = view.Subviews[0] as UILabel;
        //               // label.TextAlignment = UITextAlignment.Center;

        //            }

        //            //for (int i = 0; i < items.Length; i++)
        //            //{

        //            //    if (items[i] == null) continue;
        //            //    else
        //            //    {
        //            //        UITabBarItem item_temp = items[i];
        //            //        UIView view = item_temp.ValueForKey(new Foundation.NSString("view")) as UIView;

        //            //      //  view.BackgroundColor = UIColor.Red;

        //            //        UILabel label = view.Subviews[0] as UILabel;

        //            //       // label.Lines = 0;//or 2  

        //            //        label.TextAlignment = UITextAlignment.Center;
        //            //    }
        //            //}
        //        }
        //    }
        //    return renderer;
        //}
        protected override IShellTabBarAppearanceTracker CreateTabBarAppearanceTracker()
        {
            return new CustomShellTabBarAppearanceTracker();
        }
    }
}
