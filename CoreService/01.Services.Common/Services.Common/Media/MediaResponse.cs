namespace Services.Common.Media
{
    public class MediaResponse
    {
        public MediaResponse(string name, string path, long size)
        {
            Name = name;
            Path = path;
            Size = size;
        }
        public string Name { get; }
        public string Path { get; }
        public long Size { get; }
    }
}