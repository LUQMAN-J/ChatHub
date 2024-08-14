
using ChatHub.Models;

namespace ChatHub.Service;

public class ApiService : RestServiceBase, IApiService
{
    public ApiService(IConnectivity connectivity, IBarrel cacheBarrel) : base(connectivity, cacheBarrel)
    {
        //SetBaseURL("http://192.168.18.14:54538/api/");
    }

    public async Task<List<Store>> getStores()
    {
        await Task.Delay(100);
        return new List<Store>
        {
            new Store{StoreNumber="101",StoreName="Store A South",StoreLocation="A South Address",StorePhoneNumber="2222-222-22",StoreTimeTable="12:49 PM- 06:55 AM",StoreDistance="7 KM", StoreStatus="Close"},
            new Store{StoreNumber="102",StoreName="Store B South",StoreLocation="BSouth Address",StorePhoneNumber="2222-222-23",StoreTimeTable="12:50 PM- 06:55 AM",StoreDistance="6 KM", StoreStatus="Close"},
            new Store{StoreNumber="103",StoreName="Store C South",StoreLocation="C South Address",StorePhoneNumber="2222-222-24",StoreTimeTable="12:51 PM- 06:55 AM",StoreDistance="3 KM", StoreStatus="Close"},
            new Store{StoreNumber="104",StoreName="Store D South",StoreLocation="D South Address",StorePhoneNumber="2222-222-25",StoreTimeTable="12:52 PM- 06:55 AM",StoreDistance="4 KM", StoreStatus="Open"},
            new Store{StoreNumber="105",StoreName="Store E South",StoreLocation="E South Address",StorePhoneNumber="2222-222-26",StoreTimeTable="12:53 PM- 06:55 AM",StoreDistance="7 KM", StoreStatus="Close"},
            new Store{StoreNumber="105",StoreName="Store F South",StoreLocation="F South Address",StorePhoneNumber="2222-222-27",StoreTimeTable="12:54 PM- 06:55 AM",StoreDistance="5 KM", StoreStatus="Close"},
            new Store{StoreNumber="106",StoreName="Store G South",StoreLocation="G South Address",StorePhoneNumber="2222-222-28",StoreTimeTable="12:55 PM- 06:55 AM",StoreDistance="9 KM", StoreStatus="Close"},
            new Store{StoreNumber="107",StoreName="Store H South",StoreLocation="H South Address",StorePhoneNumber="2222-222-29",StoreTimeTable="12:56 PM- 06:55 AM",StoreDistance="5 KM", StoreStatus="Open"},
            new Store{StoreNumber="108",StoreName="Store I South",StoreLocation="I South Address",StorePhoneNumber="2222-222-30",StoreTimeTable="12:57 PM- 06:55 AM",StoreDistance="10 KM", StoreStatus="Close"},
            new Store{StoreNumber="109",StoreName="Store J South",StoreLocation="J South Address",StorePhoneNumber="2222-222-31",StoreTimeTable="12:58 PM- 06:55 AM",StoreDistance="6 KM", StoreStatus="Close"},
            new Store{StoreNumber="1010",StoreName="Store K South",StoreLocation="K South Address",StorePhoneNumber="2222-222-32",StoreTimeTable="12:59 PM- 06:55 AM",StoreDistance="4 KM", StoreStatus="Close"},
            new Store{StoreNumber="1011",StoreName="Store J South",StoreLocation="L South Address",StorePhoneNumber="2222-222-33",StoreTimeTable="12:60 PM- 06:55 AM",StoreDistance="17 KM", StoreStatus="Close"},
            new Store{StoreNumber="1012",StoreName="Store M South",StoreLocation="M South Address",StorePhoneNumber="2222-222-34",StoreTimeTable="12:01 PM- 06:55 AM",StoreDistance="4 KM", StoreStatus="Close"},
            new Store{StoreNumber="1013",StoreName="Store N South",StoreLocation="N South Address",StorePhoneNumber="2222-222-35",StoreTimeTable="12:02 PM- 06:55 AM",StoreDistance="7 KM", StoreStatus="Close"},
            new Store{StoreNumber="1014",StoreName="Store AO South",StoreLocation="O South Address",StorePhoneNumber="2222-222-36",StoreTimeTable="12:03 PM- 06:55 AM",StoreDistance="6 KM", StoreStatus="Open"}
        };
    }



}

