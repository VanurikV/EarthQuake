using Newtonsoft.Json;
using UnityEngine;

public partial class LevelManagerScript
{
    private string _loadPath = "LevelMaps/";

    private void LoadCurMap()
    {
        

        string mapPath = _loadPath + CurLevel.ToString("D2");
        TextAsset text = Resources.Load<TextAsset>(mapPath);

        CurMap = JsonConvert.DeserializeObject<MapLevel>(text.text);
        Debug.Log("Level " + CurLevel.ToString("D2") + " LOADED");
    }
}