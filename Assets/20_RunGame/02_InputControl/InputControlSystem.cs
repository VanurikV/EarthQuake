using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

public class InputControlSystem : IProtoRunSystem
{
    
    [DI] GlobalData _global;
    [DI] private MainAspect _aspect;

    private Vector3 _move;
    private float _fire;
    private ProtoEntity _ent;
    
    public void Run()
    {
        _move = _global.Controls.ControlMap.Keyboard.ReadValue<Vector2>();
        _fire = _global.Controls.ControlMap.Fire.ReadValue<float>();

        if (_move.sqrMagnitude == 0) return ;

        _move.y *= -1;
        
        //InputNormalize
        if (_move .x > 0) _move .y = 0;
        if (_move .x < 0) _move .y = 0;
        
        _ent=_aspect.World().NewEntity();
        
        ref var Inp = ref _aspect.InputControl.Add(_ent);
        Inp.isFire = _fire;
        Inp.MoveVector = _move;
        
        
    }
}
