using AdminProvider.Data.Interfaces;

namespace AdminProvider.Data.Services;

//FileService är förberett för användning då behov kommer uppstå på sikt.
//Användningsområdet är dels för att ta ut filer ur systemet - t.ex. produkt- eller kundlista.
//Sedan när vi interagerar med andra system kommer detta behövas för att kommunicera med system som inte har ett API och då behöver skicka filer istället.
public class FileService : IFileService
{
   
    
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
