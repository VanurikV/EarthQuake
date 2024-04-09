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
             //_global.Character.transform.localPosition += move.Dir * Const.CharacterSpeed * Time.deltaTime;
             _global.Character.transform.localPosition += new Vector3(move.Dir.x * Const.CharacterSpeed * Time.deltaTime,move.Dir.y * Const.CharacterSpeed * Time.deltaTime*-1,0);

             if (Vector3.Distance(_global.Character.transform.localPosition, move.DstPos) < 6)
             {
                 _global.Character.transform.localPosition = move.DstPos;
                 
                 
                 _global.Map.Grid[move.DstMap.x, move.DstMap.y].GameObject = _global.Map.Grid[move.SrcMap.x, move.SrcMap.y].GameObject;
                 _global.Map.Grid[move.DstMap.x, move.DstMap.y].Type = _global.Map.Grid[move.SrcMap.x, move.SrcMap.y].Type;

                 _global.Map.Grid[move.SrcMap.x, move.SrcMap.y].GameObject=null;
                 _global.Map.Grid[move.SrcMap.x, move.SrcMap.y].Type = CellType.Empty;
                 
                 _aspect.MoveState.Del(moveEnt);
                 _aspect.VoidState.Add(moveEnt);
             }
         }

     }
 }
