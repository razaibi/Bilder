using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using Logic;


[Command("gen")]
public class MainCommand : ICommand{
    [CommandParameter(0, Description = "Name of template to generate from.")]
    public string Template { get; init; }="";
    [CommandParameter(1, Description = "Name of template data file.")]
    public string Data { get; init; }="";
    [CommandOption("type", 't', Description = "Template type.")]
    public string TemplateType { get; init; } = "CSharp";
    [CommandOption("output", 'o', Description = "Output path.")]
    public string OutputPath { get; init; } = "Output";
    public async ValueTask ExecuteAsync(IConsole console){
        var renderedTemplate = await TemplateProcessor.GenerateTemplate(
            TemplateType,
            Template,
            Data
        );
        await Common.WriteFileAsync(OutputPath,renderedTemplate);
    }
}