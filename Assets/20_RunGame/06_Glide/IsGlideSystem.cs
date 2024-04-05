using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;


public class IsGlideSystem : IProtoRunSystem
{
    [DI] GlobalData _global;
    [DI] private MainAspect _aspect;

    [DI] ProtoIt _filterGlide = It.Chain<Position>().Inc<IsGlide>().End();


    private Vector3 _curPos;
    private Vector3 _dstPos;

    public void Run()
    {
        foreach (var ent in _filterGlide)
        {
            ref var pos = ref _aspect.Position.Get(ent);
            ref var glide = ref _aspect.IsGlide.Get(ent);
            
            pos.GameObject.transform.localPosition+= Vector3.right*glide.moveVector.x*Time.deltaTime*Const.FallSpeed;

            _curPos = pos.GameObject.transform.localPosition;
            

            if ( (_curPos.x- glide.newposf.x)*glide.moveVector.x > glide.moveVector.x)
            {
                pos.GameObject.transform.localPosition = glide.newposf;
                 
                 
                _global.Map.MapMove(glide.oldpos,glide.newpos);


                pos.MapPos.x += glide.moveVector.x;
                 
                _aspect.IsGlide.Del(ent);
                
            }


        }
    }
}