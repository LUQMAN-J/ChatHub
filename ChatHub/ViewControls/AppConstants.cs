
namespace ChatHub.ViewControl;
public static class AppConstants
{
    public static string ApplicationName = "Chat Hub";
    public static string EmailAddress = @"ranaluqmanjabbar@yahoo.com";
    public static string ApplicationId = "com.luqmanjabbar.ChatHub";
    public static string ApiServiceURL = @"SomeURL";
    public static string ApiChatURL = @"SomeURL";
    //public static string ErrorMassege = @"SomeURL";
    //public static string ErrorImage = @"SomeURL";
    public static (string Msg,string img) FromInternet(string ExceptionMessage="")
    {
        return ("Slow or no internet connection." + Environment.NewLine + "Please check you internet connection and try again.", "nointernetjson.json");
    }
    public static (string Msg, string img) FromException(string ExceptionMessage)
    {
        return ($"If the problem persists, plz contact support at {AppConstants.EmailAddress} with the error message: {Environment.NewLine} {ExceptionMessage}", "notificationjson.json");
    }
    public static (string Msg, string img) FromError(string ExceptionMessage)
    {
        return ($"{ExceptionMessage}", "notificationjson.json");
    }

}

