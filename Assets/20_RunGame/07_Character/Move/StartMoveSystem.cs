using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;



 public class StartMoveSystem : IProtoRunSystem
 {
    
    [DI] GlobalData _global;
    [DI] private MainAspect _aspect;
    
    [DI] ProtoIt _filterInput = new(It.Inc<InputControl>());
    [DI] ProtoIt _filter = It.Chain<StartState>().End();
    
    private InputControl _input;
    
    private ProtoEntity _ent;
     public void Run()
     {
         if(_filter.IsEmpty()) return;

         _ent = _filter.First().Entity;
         
         _aspect.StartState.Del(_ent);
         
         
         _input =  _aspect.InputControl.Get(_filterInput.First().Entity);
         
         Vector2Int Dst = _global.Map.GetCharacter() + Vector2Int.RoundToInt(_input.MoveVector);     
         
         
         ref var move = ref _aspect.MoveState.Add(_ent);
         
         move.Dir = _input.MoveVector;
         
         move.SrcMap = _global.Map.GetCharacter();;
         move.DstMap = Dst;
         move.SrcPos = _global.Character.transform.localPosition;
         move.DstPos = new Vector3(Dst.x * 64, Dst.y * -64, 0);
         
         _global.ScharacterScript.RunAnimation(Vector2Int.RoundToInt(_input.MoveVector));

         _global.Map.MapCopy( move.SrcMap,move.DstMap);

     }
 }
