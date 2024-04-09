using UnityEngine;

sealed partial class InitAllSystem
{
    private void CreateCharacter()
    {
        for (int y = 0; y < Const.LevelDy; y++)
        {
            for (int x = 0; x < Const.LevelDx; x++)
            {
                if (_global.Map.Grid[x, y].Type != CellType.InBox) continue;

                _global.Map.Grid[x, y].GameObjectId = 0801;
                _global.Map.Grid[x, y].Type = CellType.Character;

                GameObject o = GameObject.Instantiate(_global.AllPrefab[0801], _global.CharacterContainer.transform);
                o.transform.localPosition = new Vector3(x * 64, -y * 64);
                _global.Character = o;
                _global.ScharacterScript = o.GetComponent<CharacterScript>();
                o.SetActive(false);

                var characterEnt = _aspect.World().NewEntity();
                ref var character = ref _aspect.Character.Add(characterEnt);
                character.MapPosition = new Vector2Int(x, y);
                character.Character = _global.Character;
                character.Script = _global.ScharacterScript;

                _aspect.VoidState.Add(characterEnt);


                o = GameObject.Instantiate(_global.AllPrefab[0901], _global.GroundContainer.transform);
                o.GetComponent<WarpInScript>().SetGate(_global.EcsGate);
                o.transform.localPosition = new Vector3(x * 64, -y * 64);
                return;
            }
        }
    }
}