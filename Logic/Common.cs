namespace Logic;
using System.IO;

public class Common{
    public Common(){}
    public static async Task WriteFileAsync(string filepath, string content)
    {
        try{
            using (StreamWriter outputFile = new StreamWriter(Path.Join(Environment.CurrentDirectory, "Output", filepath)) )
            {
                await outputFile.WriteAsync(content);
            }
        }
        catch (Exception){
            Console.WriteLine("Error occurred while writing to file.");
        }
        
        
    }
}