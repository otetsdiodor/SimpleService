using SimpleService.Infrastructure.Models;
using System.Threading.Tasks;

namespace SimpleService.Infrastructure.Services.Interfaces
{
    public interface IStorage
    {
        public Task<long> GetFileSizeAsync(string path);

        public Task<long> GetDirectorySizeAsync(string path);

        public Task<StorageObjectType> GetStorageObjectTypeAsync(string path);
    }
}
