using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;


public class FallStopSystem : IProtoRunSystem
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
            ref var pos = ref _aspect.Position.Get(ent);
            ref var fall = ref _aspect.IsFall.Get(ent);

            _curPos = pos.GameObject.transform.localPosition;
            _dstPos = fall.newposf;

            if (_curPos.y - _dstPos.y > 0) continue; //достигли ли конца клетки

            pos.GameObject.transform.localPosition = fall.newposf;
            _global.Map.MapMove(fall.oldpos, fall.newpos);

            pos.MapPos.y++;

            
            _aspect.IsFall.Del(ent);
            _aspect.FallEnd.Add(ent);
        }
    }

    private void IsTouchDoun(Vector2Int pos)
    {
       
    }
}