using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using Logic;

[Command("proj")]
public class Project : ICommand{
    [CommandParameter(0, Description = "Name of current project.")]
    public string Name { get; init; }="";

    public async ValueTask ExecuteAsync(IConsole console){
        var code = await ConfigManager.SetAppSetting("currentProject", Name);
        if (code == 1){
            console.Output.WriteLine("Current project updated.");
        }
    }
}