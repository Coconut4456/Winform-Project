using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MysGame.data.script.text;

public static class TextLoader
{
    private static readonly Dictionary<string, List<string>> ScriptDic = new();
    private static readonly Dictionary<string, string> UITextDic = new();
    
    // 텍스트 불러오기
    public static void LoadTexts(string narrationPath, string dialoguePath, string uiPath)
    {
        ScriptDic.Clear();
        UITextDic.Clear();
    
        // Narration 불러오기
        if (File.Exists(narrationPath))
        {
            string narrationJson = File.ReadAllText(narrationPath);
            var narrationData = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(narrationJson);
            if (narrationData != null)
            {
                foreach (var kv in narrationData)
                    ScriptDic[kv.Key] = kv.Value;
            }
        }
    
        // Dialogue 불러오기
        if (File.Exists(dialoguePath))
        {
            string dialogueJson = File.ReadAllText(dialoguePath);
            var dialogueData = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(dialogueJson);
            if (dialogueData != null)
            {
                foreach (var kv in dialogueData)
                    ScriptDic[kv.Key] = kv.Value;
            }
        }
        
        // UI 불러오기
        if (File.Exists(uiPath))
        {
            string json = File.ReadAllText(uiPath);
            var uiData = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            if (uiData != null)
            {
                foreach (var kv in uiData)
                    UITextDic[kv.Key] = kv.Value;
            }
        }
    }
    
    public static List<string> GetScriptList(string key)
    {
        return ScriptDic.TryGetValue(key, out var list) ? list : new();
    }
    
    public static string GetUIText(string key)
    {
        return UITextDic.TryGetValue(key, out var value) ? value : "";
    }
}