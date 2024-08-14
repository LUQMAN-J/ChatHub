
using ChatHub.Models;
using Esri.ArcGISRuntime.Tasks.Geocoding;
using static System.Net.Mime.MediaTypeNames;

namespace ChatHub.Service;

public class ApiService : RestServiceBase, IApiService
{
    public ApiService(IConnectivity connectivity, IBarrel cacheBarrel) : base(connectivity, cacheBarrel)
    {
        //SetBaseURL("http://192.168.18.14:54538/api/");
    }

    private LocatorTask _geocoder;

    public async Task<List<Suggestions>> getSuggestions(string filter)
    {
        var _serviceUri = new Uri("https://geocode-api.arcgis.com/arcgis/rest/services/World/GeocodeServer");
        var inputSeparator = ',';
        _geocoder = await LocatorTask.CreateAsync(_serviceUri).ConfigureAwait(false);
        IReadOnlyList<SuggestResult> suggestions = await _geocoder.SuggestAsync(filter).ConfigureAwait(false);
        var suggestion = suggestions.Where(s => s.Label.Split(inputSeparator).ToList().Count == 5).Select(s => new Suggestions { Name = s.Label }).ToList();
        return suggestion;
    }



    public async Task<List<Stores>> getStores()
    {
        await Task.Delay(500);
        return  new List<Stores>()
            {
                new Stores() { Id = Guid.NewGuid(),Name="Karachi",Description="Based on Karachi",StoreNumber="PK=101",Status=false,Latitude=24.8607,Longitude=67.0011, Address="Karachi,Pakistan",PhoneNumber="000-123456" },
                new Stores() { Id = Guid.NewGuid(),Name="Islamabad",Description="Based on Islamabad",StoreNumber="PK=102",Status=false,Latitude=33.6995,Longitude=73.0363,Address="Islamabad,Pakistan",PhoneNumber="000-123456" },
                new Stores() { Id = Guid.NewGuid(),Name="Rawalpindi ",Description="Based on Rawalpindi",StoreNumber="PK=103",Status=false,Latitude= 33.5651,Longitude=73.0169,Address="Rawalpindi,Pakistan",PhoneNumber="000-123456" },
                new Stores() { Id = Guid.NewGuid(),Name="Lahore",Description="Based on Lahore",StoreNumber="PK=104",Status=true,Latitude= 31.520,Longitude= 74.3587 ,Address="Lahore,Pakistan",PhoneNumber="000-123456"},
                new Stores() { Id = Guid.NewGuid(),Name="Multan",Description="Based on Multan",StoreNumber="PK=105",Status=true,Latitude= 30.1864,Longitude=71.4886 ,Address="Multan,Pakistan",PhoneNumber="000-123456"}
            }.ToList();
    }
}

