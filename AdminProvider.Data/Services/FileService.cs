using AdminProvider.Data.Interfaces;

namespace AdminProvider.Data.Services;
//Överväg ta bort Fileservice.
public class FileService : IFileService
{
   
    //Byt ut här till Responseresult
    public string GetContentFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                using var sr = new StreamReader(filePath);

                return sr.ReadToEnd();
            }
            return null!;
            }
        catch
        {
            return null!;
        }
    }

    public bool SaveToFile(string filePath, string content)
    {
        try
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(content);
            return true;
        }
        catch
        {
            return false;
        }
        }
}
