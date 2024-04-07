
namespace ChatHub.Service;

public class ApiService : RestServiceBase, IApiService
{
    public ApiService(IConnectivity connectivity, IBarrel cacheBarrel) : base(connectivity, cacheBarrel)
    {
        SetBaseURL("http://192.168.18.14:54538/api/");
    }




   
}

