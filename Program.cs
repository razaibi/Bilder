using CliFx;
using Logic;

public class Program{
    static async Task Main(string[] args){   
        if (await Initialization.ReadyToRun() == true){
            await new CliApplicationBuilder()
                .AddCommandsFromThisAssembly()
                .Build()
                .RunAsync();
        };
    }
}
