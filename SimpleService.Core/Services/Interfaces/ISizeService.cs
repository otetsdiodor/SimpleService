using System.Threading.Tasks;

namespace SimpleService.Core
{
    public interface ISizeService
    {
        public Task<FileStructureSize> GetSizeAsync(string path);
    }
}
