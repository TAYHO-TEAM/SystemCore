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
    public class FileResponse
    {
        public FileResponse()
        {

        }
        public FileResponse(string fileType, byte[] archiveData, string archiveName)
        {
            FileType = fileType;
            ArchiveData = archiveData;
            ArchiveName = archiveName;
        }
        public string FileType { get; }
        public byte[] ArchiveData { get; }
        public string ArchiveName { get; }
    }
}