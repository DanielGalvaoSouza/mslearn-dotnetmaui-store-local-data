namespace People;

public class FileAccessHelper
{
    private const string DataBaseFileName = "people.db3";

    public static string GetLocalFilePath()
    {
        return System.IO.Path.Combine(FileSystem.AppDataDirectory, DataBaseFileName);
    }
}
