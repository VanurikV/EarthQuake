using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;


public enum CellType
{
    Empty = 0,
    Grass,
    Rock,
    Diamond,
    Bouble,
    StoneBlock,
    BrickBlock,
    SandBlock,
    Character,
    Warp,
    InBox,
    OutBox,
}




public class Cell
{
    public CellType Type;
    public int GameObjectId;
    public GameObject GameObject;
    public Object GameObjectScript;
}


[Serializable]
public class MapLevel
{
    public int LevelNumber;
    public string Name;
    public string Description;
    public int DiamondsRequired;
    public int Time;

    public int BackGroundId;

    public Cell[,] Grid = new Cell[Const.LevelDx, Const.LevelDy];
    
    public List<Vector2Int> PropsId = new List<Vector2Int>();

    public MapLevel()
    {
        for (int y = 0; y < Const.LevelDy; y++)
        {
            for (int x = 0; x < Const.LevelDx; x++)
            {
                Grid[x, y] = new Cell();
                Grid[x, y].Type = CellType.Empty;
            }
        }
    }

    public void MapMove(Vector2Int src, Vector2Int dst)
    {
        Grid[dst.x, dst.y].GameObjectId = Grid[src.x, src.y].GameObjectId;
        Grid[dst.x, dst.y].Type = Grid[src.x, src.y].Type;
        Grid[dst.x, dst.y].GameObject = Grid[src.x, src.y].GameObject;
        Grid[dst.x, dst.y].GameObjectScript = Grid[src.x, src.y].GameObjectScript;

        Grid[src.x, src.y].GameObjectId = 0;
        Grid[src.x, src.y].Type = CellType.Empty;
        Grid[src.x, src.y].GameObject = null;
        Grid[src.x, src.y].GameObjectScript = null;
    }
    
    public void MapCopy(Vector2Int src, Vector2Int dst)
    {
        Grid[dst.x, dst.y].GameObjectId = Grid[src.x, src.y].GameObjectId;
        Grid[dst.x, dst.y].Type = Grid[src.x, src.y].Type;
        Grid[dst.x, dst.y].GameObject = Grid[src.x, src.y].GameObject;
        Grid[dst.x, dst.y].GameObjectScript = Grid[src.x, src.y].GameObjectScript;
    }


    public Vector2Int GetCharacter()
    {
        for (int y = 0; y < Const.LevelDy; y++)
        {
            for (int x = 0; x < Const.LevelDx; x++)
            {
                if(Grid[x, y].Type ==CellType.Character) return new Vector2Int(x,y);
            }
        }
        return Vector2Int.zero;
    }
    
    public static CellType GetType(int id)
    {
        if (id >= 0100 & id < 0200) return CellType.Grass;
        if (id >= 0200 & id < 0300) return CellType.Rock;
        if (id >= 0300 & id < 0400) return CellType.Diamond;
        if (id >= 0400 & id < 0500) return CellType.Bouble;
        if (id >= 0500 & id < 0600) return CellType.StoneBlock;
        if (id >= 0600 & id < 0700) return CellType.BrickBlock;
        if (id >= 0700 & id < 0800) return CellType.SandBlock;
        if (id >= 0800 & id < 0900) return CellType.Character;
        if (id >= 0900 & id < 1000) return CellType.Warp;
        if (id >= 1000 & id < 1100) return CellType.InBox;
        if (id >= 1100 & id < 1200) return CellType.OutBox;

        return CellType.Empty;

    }
    
}