using Newtonsoft.Json;
using UnityEngine;


sealed partial class InitAllSystem
{
    private void LoadCurMap()
    {
        string _loadPath = "LevelMaps/";

        string mapPath = _loadPath + _global.CurrentLevel.ToString("D2");
        TextAsset text = Resources.Load<TextAsset>(mapPath);

        _global.Map = JsonConvert.DeserializeObject<MapLevel>(text.text);
    }
}