using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;


public static class CreateAllLevels 
{
    [MenuItem("MyTools/Create All Levels")]
    public static void CreaterLevels()
    {
       
         // string path = ".//Assets//Resources//LevelMaps//";
         //
         // for (int i = 0; i < Const.MaxLevel; i++)
         // {
         //      MapLevel level = CreateMap(i);
         //     
         //      TextWriter t = File.CreateText(path + i.ToString("D2") + ".txt");
         //      string jsonString = JsonConvert.SerializeObject(level);
         //      t.WriteLine(jsonString);
         //      t.Close();
         // }
    }

    private static MapLevel CreateMap(int num)
    {
        MapLevel level = new MapLevel();

        level.LevelNumber = num;
        level.DiamondsRequired = 5;

        
        for (int y = 0; y < Const.LevelDy; y++)
        {
            level.Grid[0, y].Type = CellType.StoneBlock;
            level.Grid[0, y].GameObjectId = 0501;
            
            level.Grid[Const.LevelDx - 1,y].Type = CellType.StoneBlock;
            level.Grid[Const.LevelDx - 1,y].GameObjectId = 0501;
        }
        
        for (int x = 0; x < Const.LevelDx; x++)
        {
            level.Grid[x, 0].Type=CellType.StoneBlock;
            level.Grid[x, 0].GameObjectId = 0501;
            
            level.Grid[x, Const.LevelDy - 1].Type = CellType.StoneBlock;
            level.Grid[x, Const.LevelDy - 1].GameObjectId = 0501;
        }

        level.Grid[0, 0].Type = CellType.StoneBlock;
        level.Grid[0, 0].GameObjectId = 0502;
        
        level.Grid[Const.LevelDx - 1, 0].Type=CellType.StoneBlock;
        level.Grid[Const.LevelDx - 1, 0].GameObjectId = 0502;

        level.Grid[0, Const.LevelDy - 1].Type = CellType.StoneBlock;
        level.Grid[0, Const.LevelDy - 1].GameObjectId = 0502;

        level.Grid[Const.LevelDx - 1, Const.LevelDy - 1].Type = CellType.StoneBlock;
        level.Grid[Const.LevelDx - 1, Const.LevelDy - 1].GameObjectId = 0502;

        level.PropsId = new List<Vector2Int>();
        
        
        
        return level;
    }
}
