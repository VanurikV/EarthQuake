using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;


 public class BehaviourSystem : IProtoRunSystem
 {
    
    [DI] GlobalData _global;
    [DI] private MainAspect _aspect;

    [DI] ProtoIt _filterIdel = It.Chain<IdleState>().End();
    [DI] ProtoIt _filterInput = new (It.Inc<InputControl> ());

    private ProtoEntity ent;
    
     public void Run()
     {

         foreach (var idelEnt in _filterIdel)
         {
             foreach (var inputEnt in _filterInput)    
             {
                 ref var input = ref _aspect.InputControl.Get(inputEnt);
                 var CharPos = _global.Map.GetCharacter();
                 Vector2Int Dst = CharPos + Vector2Int.RoundToInt(input.MoveVector);
                 
                 if (input.isFire == 0)
                 {
                     if(_global.Map.Grid[Dst.x, Dst.y].Type == CellType.Empty);
                     {
                        _aspect.World().DelEntity(idelEnt); 
                        
                        ent = _aspect.World().NewEntity();
                        ref var move = ref _aspect.MoveState.Add(ent);

                        move.Dir = input.MoveVector;

                        move.SrcMap = CharPos;
                        move.DstMap = Dst;
                        move.SrcPos = _global.Character.transform.localPosition;
                        move.DstPos = new Vector3(Dst.x*64,Dst.y*-64,0);
                        
                        _global.ScharacterScript.RunAnimation(Vector2Int.RoundToInt(input.MoveVector));

                     }
                 }
                 
                 

             }
         }
     }
 }
