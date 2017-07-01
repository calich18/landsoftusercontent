using Landsoft.UserContent.Models;
using System.Threading.Tasks;

namespace Landsoft.UserContent.DAL
{
    public interface IImageRepository
    {
        Task<int> CreateAsync(Image image);
        Task<Image> FindOneAsync(string imageId);
    }
}