using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace Logic;

public class Initialization{
    public Initialization(){}
    public static async Task<bool> ReadyToRun(){
        bool readyToRun = false;
        bool foldersSetup = false;
        foldersSetup = await FoldersSetup();
        if (foldersSetup == true){
            readyToRun = true;
        }
        return await Task.FromResult(readyToRun);
    }

    private static async Task<bool> FoldersSetup(){
        bool allFoldersExist = true; 
        string[] initialFolderList = {
            "Data",
            "Output",
            "Templates"
        };

        foreach (var item in initialFolderList){
            if(!Directory.Exists(item)){
                allFoldersExist = false;
            }
        }

        if (!allFoldersExist){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Project folders incorrectly setup.");
            Console.ResetColor();
        }

        return await Task.FromResult(allFoldersExist);
    }
}