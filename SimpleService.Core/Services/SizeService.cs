using SimpleService.Infrastructure.Models;
using SimpleService.Infrastructure.Services.Interfaces;
using System.Threading.Tasks;

namespace SimpleService.Core
{
    public class SizeService : ISizeService
    {
        private readonly IStorage storage;

        public SizeService(IStorage storage)
        {
            this.storage = storage;
        }

        public async Task<FileStructureSize> GetSizeAsync(string path)
        {
            var structType = await storage.GetStorageObjectTypeAsync(path);
            long structSize = 0;
            switch (structType)
            {
                case StorageObjectType.File:
                    structSize = await storage.GetFileSizeAsync(path);
                    break;
                case StorageObjectType.Directory:
                    structSize = await storage.GetDirectorySizeAsync(path);
                    break;
                default:
                    break;
            }

            return new FileStructureSize(structSize, "Bytes");
        }
    }
}
