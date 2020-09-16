using RecipeCommunityRESTApi.Db.RecipeCommunity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeCommunityWebApp.ApiServices
{
    public interface ICuisinesService
    {
        Task<IEnumerable<Cuisine>> GetCuisines();
    }
}
