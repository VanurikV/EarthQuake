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
        _move = _global.controls.ControlMap.Keyboard.ReadValue<Vector2>();
        _fire = _global.controls.ControlMap.Fire.ReadValue<float>();

        if (_move.sqrMagnitude == 0) return ;

        _ent=_aspect.World().NewEntity();
        _aspect.OneFrame.Add(_ent);

        ref var Inp = ref _aspect.InputControl.Add(_ent);
        Inp.isFire = _fire;
        Inp.MoveVector = _move;
        
    }
}
