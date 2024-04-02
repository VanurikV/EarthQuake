using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public partial class LevelManagerScript
{
    private string MapPath = ".//Assets//Resources//LevelMaps//";
    
    public void SaveCurMap()
    {
        TextWriter t = File.CreateText(MapPath + CurLevel.ToString("D2") + ".txt");

        string jsonString = JsonConvert.SerializeObject(CurMap);
        t.WriteLine(jsonString);
        t.Close();

        Debug.Log("Level " + CurLevel.ToString("D2") + " SAVE");
    }
}