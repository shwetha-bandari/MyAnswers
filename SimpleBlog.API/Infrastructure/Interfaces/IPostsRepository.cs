using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlog.API.Infrastructure 
{
    public interface IPostsRepository 
    {
        Task<IList<T>> GetAll<T>();
        Task<IList<T>> GetN<T>(int count);
        Task<T> Get<T>(int id);
        Task<T> Details<T>(int id, string slug);
        
    }
}