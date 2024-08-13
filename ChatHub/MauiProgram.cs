using Esri.ArcGISRuntime;
using Esri.ArcGISRuntime.Maui;
using Esri.ArcGISRuntime.Toolkit.Maui;
using Mopups.Hosting;
using zoft.MauiExtensions.Controls;
using The49.Maui.BottomSheet;

#if ANDROID
using ChatHub.Platforms.Android;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#elif IOS
using ChatHub.Platforms.iOS;

#endif



namespace ChatHub;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseSkiaSharp()
            .UseMauiCommunityToolkit()
            .ConfigureMopups()
            .UseArcGISToolkit()
            .UseBottomSheet()
            .UseZoftAutoCompleteEntry()
            .UseArcGISRuntime(config => config.UseApiKey("AAPK2c42ebedf7f84f13b962351af2d1f8c45FR6ihcxBhNGhASsva2b2expAWzq6Qi_u_3Vmjgfe_nsan8A2GjN0JcgFm_AGvcL"))
            .ConfigureLifecycleEvents(events =>
             {
                 RegisterAnriodLifeCycleServices(events);
             })
             .ConfigureMauiHandlers(handlers =>
                {
                    #if ANDROID || IOS
                      handlers.AddHandler<Shell, ShellHandler>();
                    #endif
                })
            .ConfigureEssentials(essentials =>
            {
                essentials.UseVersionTracking();
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Comfortaa-Regular.ttf", "RegularFont");
                fonts.AddFont("Comfortaa-Bold.ttf", "BoldFont");
                fonts.AddFont("Comfortaa-Medium.ttf", "MediumFont");
                fonts.AddFont("Comfortaa-SemiBold.ttf", "SemiBoldFont");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
#if ANDROID
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (h, v) =>
        {
            h.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
        });
#endif
        RegisterAppServices(builder.Services);
        return builder.Build();
    }



    private static void RegisterAnriodLifeCycleServices(ILifecycleBuilder events)
    {
#if ANDROID
        events.AddAndroid(android => android.OnCreate((activity, bundle) => MakeStatusBarTranslucent(activity)));
        static void MakeStatusBarTranslucent(Android.App.Activity activity) => activity.Window.SetStatusBarColor(Android.Graphics.Color.Black);
#endif
    }
    private static void RegisterAppServices(IServiceCollection services)
    {
        //Add Platform specific Dependencies
        services.AddSingleton<IConnectivity>(Connectivity.Current);

        //Register Cache Barrel
        Barrel.ApplicationId = AppConstants.ApplicationId;
        services.AddSingleton<IBarrel>(Barrel.Current);
        //Register API Service
        services.AddSingleton<IApiService, ApiService>();
        services.AddSingleton<LoginPageViewModel>();
        services.AddSingleton<HomePageViewModel>();
        services.AddSingleton<ChatPageViewModel>();
        services.AddSingleton<RegisterPageViewModel>();
        services.AddSingleton<BaseMapViewModel>();
    }


}

