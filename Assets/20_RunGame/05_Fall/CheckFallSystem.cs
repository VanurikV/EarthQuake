using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;


 public class CheckFallSystem : IProtoRunSystem
 {
    
    [DI] GlobalData _global;
    [DI] private MainAspect _aspect;

    [DI] ProtoItExc _filterFall = It.Chain<Position>().Inc<CanFall>().Exc<IsFall>().Exc<IsGlide>().End();
   
    
    
     public void Run()
     {
         foreach (var ent in _filterFall)
         {
             ref var pos = ref _aspect.Position.Get(ent).MapPos;
             if (_global.Map.Grid[pos.x, pos.y+1].Type == CellType.Empty)
             {
                 ref var fall = ref _aspect.IsFall.Add(ent);
                 fall.oldpos = pos;
                 fall.newpos = pos + new Vector2Int(0,1);
                 fall.newposf = new Vector3(pos.x * 64, (pos.y + 1) * -64);

                 ((IFall)(_global.Map.Grid[pos.x, pos.y].GameObjectScript))?.Fall(true);
                 
                 
                 
             }
         }

     }
 }

