using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;
using UnityEngine.UIElements;


public class CheckGlideSystem : IProtoRunSystem
{
    [DI] GlobalData _global;
    [DI] private MainAspect _aspect;

    [DI] ProtoItExc _filterGlide = It.Chain<Position>().Inc<CanGlide>().Exc<IsFall>().Exc<IsGlide>().End();


    public void Run()
    {
        int k = 0;
        
        foreach (var ent in _filterGlide)
        {
            ref var pos = ref _aspect.Position.Get(ent).MapPos;
            

            if ( !((_global.Map.Grid[pos.x, pos.y + 1].Type == CellType.Diamond) ||
                 (_global.Map.Grid[pos.x, pos.y + 1].Type == CellType.Rock))) continue;
            
            
            if (_global.Map.Grid[pos.x + 1, pos.y].Type == CellType.Empty && _global.Map.Grid[pos.x + 1, pos.y+1].Type == CellType.Empty ) 
            {
                k = +1;
            }
            else if (_global.Map.Grid[pos.x - 1, pos.y].Type == CellType.Empty && _global.Map.Grid[pos.x - 1, pos.y+1].Type == CellType.Empty)
            {
                k = -1;
            }
            else
            {
                continue;
            }
            
            ref var fall = ref _aspect.IsGlide.Add(ent);
            fall.oldpos = pos;
            fall.newpos = pos + new Vector2Int(k, 0);
            fall.newposf = new Vector3((pos.x + k) * 64, pos.y * -64);

            fall.moveVector = Vector2Int.right * k;
            
            _global.Map.MapCopy(fall.oldpos,fall.newpos);

        }


        
    }
}