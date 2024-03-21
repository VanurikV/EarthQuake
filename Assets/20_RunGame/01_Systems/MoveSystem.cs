using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;


 public class MoveSystem : IProtoRunSystem
 {
    
    [DI] GlobalData _global;
    [DI] private MainAspect _aspect;

    [DI] ProtoIt _filterMove = It.Chain<MoveState>().End();
    
    
     public void Run()
     {
         foreach (var moveEnt in _filterMove)
         {
             ref var move = ref _aspect.MoveState.Get(moveEnt);
             _global.Character.transform.localPosition += move.Dir * Const.CharacterSpeed * Time.deltaTime;
         }

     }
 }
