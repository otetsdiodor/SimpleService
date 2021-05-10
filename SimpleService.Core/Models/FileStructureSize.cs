namespace SimpleService.Core
{
    public class FileStructureSize
    {
        public long Size { get; set; }

        public string MeasureType { get; set; }

        public FileStructureSize(long size, string measureType)
        {
            Size = size;
            MeasureType = measureType;
        }
    }
}
