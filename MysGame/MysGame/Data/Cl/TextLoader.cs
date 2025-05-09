using System.Net;
using System.Text.Json;

namespace MysGame.Data.Cl;

public class TextLoader
{
    private static Dictionary<string, List<string>> _scriptList = new();

    public static void Load(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException("Text File not found");

        string json = File.ReadAllText(path);
        
        _scriptList = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(json);
    }

    public static List<string> GetScriptList(string key)
    {
        if (_scriptList == null)
            throw new InvalidOperationException("Text File not loaded");
        
        return _scriptList.TryGetValue(key, out var list) ? list : new();
    }
}