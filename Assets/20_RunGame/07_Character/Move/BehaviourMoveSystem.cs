using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;



 public class BehaviourMoveSystem : IProtoRunSystem
 {
    
     [DI] GlobalData _global;
     [DI] private MainAspect _aspect;

     [DI] ProtoIt _filterIdel = It.Chain<IdleState>().End();
     [DI] ProtoIt _filterVoid = It.Chain<VoidState>().End();

     [DI] ProtoIt _filterInput = new(It.Inc<InputControl>());

     private ProtoEntity _ent;

     private Vector2Int CharPos;
     private InputControl _input;

     
     public void Run()
     {
         if (!_filterVoid.IsEmpty() && _filterInput.IsEmpty())
         {
             var ent = _filterVoid.First().Entity;
             _aspect.IdleState.Add(ent);
             _aspect.VoidState.Del(ent);
             
             _global.ScharacterScript.RunAnimation(CharacterAnimation.IdleFrontAnim);
             return;
         }
         
         if ((!_filterIdel.IsEmpty() && !_filterInput.IsEmpty())   ||  (!_filterVoid.IsEmpty() && !_filterInput.IsEmpty()) )
         {
             var inputEnt = _filterInput.First().Entity;
             _input =  _aspect.InputControl.Get(inputEnt);

             

             if (!_filterIdel.IsEmpty())
             {
                 _ent = _filterIdel.First().Entity;
                 _aspect.IdleState.Del(_ent);
             }

             if (!_filterVoid.IsEmpty())
             {
                 _ent = _filterVoid.First().Entity;
                 _aspect.VoidState.Del(_ent);
             }
             
             
             CharPos = _global.Map.GetCharacter();
             Vector2Int Dst = CharPos + Vector2Int.RoundToInt(_input.MoveVector);     
            
             if (_input.isFire == 0)
             {
                 if (_global.Map.Grid[Dst.x, Dst.y].Type == CellType.Empty)
                 {
                     _aspect.StartState.Add(_ent);
                     return;
                 }
                 if (_global.Map.Grid[Dst.x, Dst.y].Type == CellType.Grass)
                 {
                    
                     ref var removeGrass = ref _aspect.RemoveGrass.Add(_aspect.World().NewEntity());
                     removeGrass.GrassMap = Dst;
                    
                     _aspect.StartState.Add(_ent);
                     return;
                 }
                
                 _aspect.IdleState.Add(_ent);
             }
         }

     }
 }
