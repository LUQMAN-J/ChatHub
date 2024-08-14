



using ChatHub.Models;

namespace ChatHub.IServices;

public interface IApiService
{
    Task<List<Store>> getStores();


}

