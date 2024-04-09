using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

 public class RemoveGrassSystem : IProtoRunSystem
 {
    
    [DI] GlobalData _global;
    [DI] private MainAspect _aspect;

    [DI] ProtoIt _filterGrass = It.Chain<RemoveGrass>().End();
    
     public void Run()
     {

         foreach (var grass in _filterGrass)
         {
             ref var GrassMap = ref _aspect.RemoveGrass.Get(grass).GrassMap;
             ((GrassScript)(_global.Map.Grid[GrassMap.x, GrassMap.y].GameObjectScript)).Fade();
             _aspect.World().DelEntity(grass);
             
             //var sfxEnt = _aspect.World().NewEntity();
             //ref var sfx = ref _aspect.SoundFx.Add(sfxEnt);
             //sfx.SfxClip = SfxEnum.GrassFade;
         }

     }
 }
