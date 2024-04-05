using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;


 public class FallEndSystem : IProtoRunSystem
 {
     [DI] GlobalData _global;
     [DI] private MainAspect _aspect;
     
     [DI] ProtoIt _filterFall = It.Chain<Position>().Inc<FallEnd>().End();

    
     public void Run()
     {
         foreach (var ent in _filterFall)
         {
             ref var pos = ref _aspect.Position.Get(ent);



             if (_global.Map.Grid[pos.MapPos.x, pos.MapPos.y + 1].Type == CellType.Empty)
             {
                 _aspect.IsFall.Del(ent);
                 _aspect.FallEnd.Del(ent);
                 continue;
                     
             }


             //Debug.Log(pos);

             ref var fx = ref _aspect.SoundFx.Add(_aspect.World().NewEntity());

             if (_global.Map.Grid[pos.MapPos.x, pos.MapPos.y].Type == CellType.Diamond)
             {
                 fx.SfxClip = SfxEnum.DiamondFall;
                 ((IFall)(_global.Map.Grid[pos.MapPos.x, pos.MapPos.y].GameObjectScript)).Fall(false);
             }

             if (_global.Map.Grid[pos.MapPos.x, pos.MapPos.y].Type == CellType.Rock)
             {
                 fx.SfxClip = SfxEnum.RockFall;
                ((IFall)(_global.Map.Grid[pos.MapPos.x, pos.MapPos.y].GameObjectScript)).Fall(false);
             }
             
             _aspect.FallEnd.Del(ent);
         }
     }
 }
