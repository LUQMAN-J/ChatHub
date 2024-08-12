



using ChatHub.Models;

namespace ChatHub.IServices;

public interface IApiService
{

    Task<List<Suggestions>> getSuggestions(string filter);


}

