using UnityEngine;

sealed partial class InitAllSystem
{
    private void CreateGrass()
    {
        for (int y = 0; y < Const.LevelDy; y++)
        {
            for (int x = 0; x < Const.LevelDx; x++)
            {
                if (_global.Map.Grid[x, y].Type == CellType.Empty) continue;
                if (_global.Map.Grid[x, y].Type != CellType.Grass) continue;

                var o = GameObject.Instantiate(_global.AllPrefab[_global.Map.Grid[x, y].GameObjectId],
                    _global.StoneBlockContainer.transform);
                o.transform.localPosition = new Vector3(x * 64, -y * 64);

                _global.Map.Grid[x, y].GameObject = o;
                _global.Map.Grid[x, y].GameObjectScript = o.GetComponent<GrassScript>();
            }
        }
    }
}