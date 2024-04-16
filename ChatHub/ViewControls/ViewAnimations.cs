using System;
using System.Threading.Tasks;

namespace ChatHub.ViewControl;

   public static class ViewAnimations
    {
        public static async Task FadeAnimY(View view)
        {


            await Task.WhenAll
               (
                    view.FadeTo(1, 400),
                    view.TranslateTo(0, 0, 2400)
               );
        }
    }

