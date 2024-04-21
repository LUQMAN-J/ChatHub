using System;
using System.Threading.Tasks;

namespace ChatHub.ViewControl;

public static class ViewAnimations
{
    private const string AnimationKey = "Animation";
    private const uint AnimationLength = 400;
    public static async Task FadeAnimY(View view)
    {
        //await Task.WhenAll
        //   (
        //        view.FadeTo(1, 200),
        //        view.TranslateTo(0, 0, 200)
        //   );
        view.AbortAnimation(AnimationKey);
        var animation = new Animation
            {
                { 0, 1, new Animation (v => view.FadeTo(1)) },
                { 0, 1, new Animation (v => view.TranslateTo(0, 0)) },
            };
        animation.Commit(view, AnimationKey, 16, AnimationLength, Easing.SpringIn);
        await Task.Delay((int)AnimationLength);

    }
}

