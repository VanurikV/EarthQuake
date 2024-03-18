using Leopotam.EcsProto.QoL;
using UnityEngine;

sealed partial class InitAllSystem
{
    private void CreateObject()
    {
        for (int y = 0; y < Const.LevelDy; y++)
        {
            for (int x = 0; x < Const.LevelDx; x++)
            {
                if (_global.CurMap.Map[x, y].Type == CellType.Empty) continue;


                switch (_global.CurMap.Map[x, y].Type)
                {
                    case CellType.Grass:
                        o = GameObject.Instantiate(_global.AllPrefab[_global.CurMap.Map[x, y].GameObjectId],
                            _global.GroundContainer.transform);
                        o.transform.localPosition = new Vector3(x * 64, -y * 64);
                        _global.CurMap.Map[x, y].GameObject = o;
                        _global.CurMap.Map[x, y].GameObjectScript = o.GetComponent<GrassScript>();

                        //((GrassScript)(_global.CurMap.Map[x, y].GameObjectScript)).Fade();

                        break;


                    case CellType.StoneBlock:
                        o = GameObject.Instantiate(_global.AllPrefab[_global.CurMap.Map[x, y].GameObjectId], _global.StoneBlockContainer.transform);
                        o.transform.localPosition = new Vector3(x * 64, -y * 64);
                        break;


                    case CellType.InBox:
                        _global.CurMap.Map[x, y].GameObjectId = 0801;
                        _global.CurMap.Map[x, y].Type = CellType.Character;

                        o = GameObject.Instantiate(_global.AllPrefab[0801], _global.CharacterContainer.transform);
                        o.transform.localPosition = new Vector3(x * 64, -y * 64);
                        _global.ScharacterScript = o.GetComponent<CharacterScript>();
                        o.SetActive(false);

                        // var characterEnt = _aspect.World().NewEntity();
                        // ref var cc = ref _aspect.Character.Add(characterEnt);
                        // cc.CurMapPosition = new Vector2Int(x, y);
                        // cc.CharacterContainer = _global.CharacterContainer;
                        // cc.ScharacterScript = _global.ScharacterScript;
                        //
                        // _aspect.IdleCharState.Add(characterEnt);

                        o = GameObject.Instantiate(_global.AllPrefab[0901], _global.GroundContainer.transform);
                        o.GetComponent<WarpInScript>().SetGate(_global.EcsGate); 
                        o.transform.localPosition = new Vector3(x * 64, -y * 64);
                        
                        
                        
                         
                        
                        var sfxEnt = _aspect.World().NewEntity();
                        ref var sfx = ref _aspect.SoundFx.Add(sfxEnt);
                        sfx.SfxClip = SfxEnum.WarpIn;
                        _aspect.OneFrame.Add(sfxEnt);


                        break;


                    default:
                        o = GameObject.Instantiate(_global.AllPrefab[_global.CurMap.Map[x, y].GameObjectId], _global.GroundContainer.transform);
                        o.transform.localPosition = new Vector3(x * 64, -y * 64);
                        break;
                }
            }
        }
    }
}