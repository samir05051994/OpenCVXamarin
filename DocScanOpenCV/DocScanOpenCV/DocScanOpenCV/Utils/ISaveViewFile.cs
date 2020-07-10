using System.IO;


namespace DocScanOpenCV.Utils
{
    public interface ISaveViewFile
    {
        string SaveAndViewAsync(string filename, MemoryStream stream);
    }
}
