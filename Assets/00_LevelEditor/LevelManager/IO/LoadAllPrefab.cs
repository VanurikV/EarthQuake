using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public partial class LevelManagerScript
{
    private void LoadAllPrefabs()
    {
        AllPrefab = new Dictionary<int, GameObject>();

        TextAsset ts = Resources.Load<TextAsset>("IndexPrefab");
        List<string> prefName = ts.text.Trim().Replace("\r", "").Split('\n').ToList();

        foreach (string fs in prefName)
        {
            int index = int.Parse(Path.GetFileNameWithoutExtension(fs).Substring(0, 4));
            AllPrefab[index] = Resources.Load<GameObject>(fs);
        }

        Debug.Log("Loaded " + AllPrefab.Count.ToString("D3") + " prefabs");
    }
}