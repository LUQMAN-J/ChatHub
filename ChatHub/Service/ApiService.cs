
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
}

