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
    [DI] ProtoIt _filterVoid = It.Chain<VoidState>().End();

    [DI] ProtoIt _filterInput = new(It.Inc<InputControl>());

    private ProtoEntity ent;

    private Vector2Int CharPos;
    private InputControl _input;
    
    public void Run()
    {
        if (!_filterVoid.IsEmpty() && _filterInput.IsEmpty())
        {
            _aspect.World().DelEntity(_filterVoid.First().Entity);
            _aspect.IdleState.Add(_aspect.World().NewEntity());
            _global.ScharacterScript.RunAnimation(CharacterAnimation.IdleFrontAnim);
            return;
        }

        if ((!_filterIdel.IsEmpty() && !_filterInput.IsEmpty())   ||  (!_filterVoid.IsEmpty() && !_filterInput.IsEmpty()) )
        {
            var inputEnt = _filterInput.First().Entity;
            _input =  _aspect.InputControl.Get(inputEnt);
            InputNormalize();
                
            CharPos = _global.Map.GetCharacter();
            Vector2Int Dst = CharPos + Vector2Int.RoundToInt(_input.MoveVector);     
            
            if (_input.isFire == 0)
            {
                if (_global.Map.Grid[Dst.x, Dst.y].Type == CellType.Empty)
                {
                    MoveCharacter();
                }
                if (_global.Map.Grid[Dst.x, Dst.y].Type == CellType.Grass)
                {
                    ent = _aspect.World().NewEntity();
                    ref var removeGrass = ref _aspect.RemoveGrass.Add(ent);
                    removeGrass.GrassMap = Dst;
                    
                    MoveCharacter();
                }
                
            }
        }

        
    }

    private void MoveCharacter()
    {
        if (!_filterIdel.IsEmpty()) _aspect.World().DelEntity(_filterIdel.First().Entity);
        if (!_filterVoid.IsEmpty()) _aspect.World().DelEntity(_filterVoid.First().Entity);
        
        
        Vector2Int Dst = CharPos + Vector2Int.RoundToInt(_input.MoveVector);     
        
        ent = _aspect.World().NewEntity();
        ref var move = ref _aspect.MoveState.Add(ent);

        move.Dir = _input.MoveVector;

        move.SrcMap = CharPos;
        move.DstMap = Dst;
        move.SrcPos = _global.Character.transform.localPosition;
        move.DstPos = new Vector3(Dst.x * 64, Dst.y * -64, 0);

        _global.ScharacterScript.RunAnimation(Vector2Int.RoundToInt(_input.MoveVector));
       
    }

    private void InputNormalize()
    {
        if (_input.MoveVector.x > 0) _input.MoveVector.y = 0;
        if (_input.MoveVector.x < 0) _input.MoveVector.y = 0;
    }
}