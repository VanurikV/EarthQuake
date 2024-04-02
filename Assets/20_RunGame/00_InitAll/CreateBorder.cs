using UnityEngine;

sealed partial class InitAllSystem
{
    private void CreateBorder()
    {
        for (int y = 0; y < Const.LevelDy; y++)
        {
            for (int x = 0; x < Const.LevelDx; x++)
            {
                if (_global.Map.Grid[x, y].Type == CellType.Empty) continue;
                if (_global.Map.Grid[x, y].Type != CellType.StoneBlock) continue;
                
                    var o = GameObject.Instantiate(_global.AllPrefab[_global.Map.Grid[x, y].GameObjectId],
                        _global.StoneBlockContainer.transform);
                    o.transform.localPosition = new Vector3(x * 64, -y * 64);
                
            }
        }
    }
}