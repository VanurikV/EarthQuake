using UnityEngine;

sealed partial class InitAllSystem
{
    private void CreateRock()
    {
        for (int y = 0; y < Const.LevelDy; y++)
        {
            for (int x = 0; x < Const.LevelDx; x++)
            {
                if (_global.Map.Grid[x, y].Type == CellType.Empty) continue;
                if (_global.Map.Grid[x, y].Type != CellType.Rock) continue;

                var o = GameObject.Instantiate(_global.AllPrefab[_global.Map.Grid[x, y].GameObjectId],
                    _global.StoneBlockContainer.transform);
                o.transform.localPosition = new Vector3(x * 64, -y * 64);

                _global.Map.Grid[x, y].GameObject = o;
                _global.Map.Grid[x, y].GameObjectScript = o.GetComponent<RockScript>();

                var rockEnt = _aspect.World().NewEntity();
                ref var pos = ref _aspect.Position.Add(rockEnt);
                pos.MapPos = new Vector2Int(x, y);
                pos.GameObject = o;


                _aspect.CanFall.Add(rockEnt);
                _aspect.CanGlide.Add(rockEnt);
            }
        }
    }
}