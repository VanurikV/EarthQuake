using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;



public class CreatePrefabList 
{
    [MenuItem("MyTools/Create Prefab List")]
    public static void CreateList()
    {
        string path = ".//Assets//Resources//Prefabs//";

        List<string> AllPrefString = Directory.GetFiles(path, "*.prefab", SearchOption.AllDirectories).ToList();
        
        AllPrefString= AllPrefString.Select(s => s.Substring(22).Replace("//", "/").Replace("\\","/")).ToList();

        AllPrefString = AllPrefString.Select(s => s.Substring(0, s.Length - 7)).ToList();

        
        using (TextWriter t=File.CreateText(".//Assets//Resources//IndexPrefab.txt"))
        {
            foreach (string prefName in AllPrefString)
            {
                t.WriteLine(prefName);
            }
        }
        Debug.Log("IndexPrefab Generated");
    }
}
