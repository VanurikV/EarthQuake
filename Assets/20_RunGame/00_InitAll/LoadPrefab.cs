using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

sealed partial class InitAllSystem
{
    private void LoadAllPrefabs()
    {
        _global.AllPrefab = new Dictionary<int, GameObject>();

        TextAsset ts = Resources.Load<TextAsset>("IndexPrefab");
        List<string> prefName = ts.text.Trim().Replace("\r", "").Split('\n').ToList();

        foreach (string fs in prefName)
        {
            int index = int.Parse(Path.GetFileNameWithoutExtension(fs).Substring(0, 4));
            _global.AllPrefab[index] = Resources.Load<GameObject>(fs);
        }
    }
}