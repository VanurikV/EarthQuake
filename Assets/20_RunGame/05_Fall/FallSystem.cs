using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;


public class FallSystem : IProtoRunSystem
{
    [DI] GlobalData _global;
    [DI] private MainAspect _aspect;

    [DI] ProtoIt _filterFall = It.Chain<Position>().Inc<IsFall>().End();


    

    public void Run()
    {
        foreach (var ent in _filterFall)
        {
            ref var pos = ref _aspect.Position.Get(ent);
            pos.GameObject.transform.localPosition+=Vector3.down*Time.deltaTime*Const.FallSpeed;
        }
    }
}