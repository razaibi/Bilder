namespace Logic;

using System.Dynamic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class ConfigManager{

    const string AppSettingsPath = "appsettings.json";
    public ConfigManager(){}

    public static async Task<dynamic> GetAppSettings(){
        var appSettingsPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), AppSettingsPath);
        var json = File.ReadAllText(appSettingsPath);
        var jsonSettings = new JsonSerializerSettings();
        jsonSettings.Converters.Add(new ExpandoObjectConverter());
        jsonSettings.Converters.Add(new StringEnumConverter());
        dynamic? config = JsonConvert.DeserializeObject<ExpandoObject>(json, jsonSettings);
        return await Task.FromResult<dynamic>(config);
    }

    public static async Task<int> SetAppSetting(
            string configKey, 
            string configVal
    ){
        dynamic config = GetAppSettings().Result;
        ((IDictionary<string, object>)config)[configKey] = configVal;
        var jsonSettings = new JsonSerializerSettings();
        jsonSettings.Converters.Add(new ExpandoObjectConverter());
        jsonSettings.Converters.Add(new StringEnumConverter());
        var newJson = JsonConvert.SerializeObject(config, Formatting.Indented, jsonSettings);
        File.WriteAllText(AppSettingsPath, newJson);
        return await Task.FromResult<int>(1); 
    }

    public static string GetAppSettingByKey(
            string configKey
    ){
        dynamic config = GetAppSettings();
        return config.configKey;
    }
}