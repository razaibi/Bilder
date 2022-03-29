using HandlebarsDotNet;
using YamlDotNet.Serialization;

namespace Logic;

public class TemplateProcessor{
    public TemplateProcessor(){}
    public static async Task<string> GenerateTemplate(
        string templateType,
        string templateName,
        string templateDataFile
    ){
        var templateDataPath = Path.Join(
            "Data", 
            templateDataFile
        );

        var rawTemplatePath = Path.Join(
            "Templates",
            templateType, 
            templateName
        );

        string templateData = System.IO.File.ReadAllText(
            $"{templateDataPath}.yml"
        );

        string rawTemplate = System.IO.File.ReadAllText(
            $"{rawTemplatePath}.handlebars"
        );

        var stringReader = new StringReader(templateData);
        var deserializer = new Deserializer();
        var yamlObject = deserializer.Deserialize(stringReader);
        var template = Handlebars.Compile(rawTemplate);
        var renderedTemplate = template(yamlObject);
        return await Task.FromResult<string>(renderedTemplate);
    }
}