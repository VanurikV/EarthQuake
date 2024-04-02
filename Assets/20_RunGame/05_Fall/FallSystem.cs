using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;


public class IsFallSystem : IProtoRunSystem
{
    [DI] GlobalData _global;
    [DI] private MainAspect _aspect;

    [DI] ProtoIt _filterFall = It.Chain<Position>().Inc<IsFall>().End();


    private Vector3 _curPos;
    private Vector3 _dstPos;

    public void Run()
    {
        foreach (var ent in _filterFall)
        {
        }
    }
}