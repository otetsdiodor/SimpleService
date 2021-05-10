using SimpleService.Infrastructure.Exceptions;
using SimpleService.Infrastructure.Models;
using SimpleService.Infrastructure.Services.Interfaces;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleService.Infrastructure.Services
{
    public class WindowsStorage : IStorage
    {
        public Task<long> GetDirectorySizeAsync(string path)
        {
            return Task.Run(() =>
            {
                Validate(path);

                var directoryInfo = new DirectoryInfo(path);
                return GetDirSize(directoryInfo);
            });
        }

        public Task<long> GetFileSizeAsync(string path)
        {
            return Task.Run(() =>
            {
                Validate(path);

                var fileInfo = new FileInfo(path);
                return fileInfo.Length;
            });
        }

        public Task<StorageObjectType> GetStorageObjectTypeAsync(string path)
        {
            return Task.Run(() =>
            {
                Validate(path);

                FileAttributes attr = File.GetAttributes(path);
                if (attr.HasFlag(FileAttributes.Directory))
                {
                    return StorageObjectType.Directory;
                }

                return StorageObjectType.File;
            });
        }

        private void Validate(string path)
        {
            var fileInfo = new FileInfo(path);
            var directoryInfo = new DirectoryInfo(path);
            if (!fileInfo.Exists && !directoryInfo.Exists)
            {
                throw new NotFoundException("File or Dir does not exists");
            }
        }

        private long GetDirSize(DirectoryInfo directoryInfo)
        {
            var currFileSize = directoryInfo.EnumerateFiles().Sum(x => x.Length);
            currFileSize += directoryInfo.EnumerateDirectories().Sum(GetDirSize);
            return currFileSize;
        }
    }
}
