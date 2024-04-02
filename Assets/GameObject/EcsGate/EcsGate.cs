using System.Collections;
using System.Collections.Generic;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using UnityEngine;

public class EcsGate : MonoBehaviour
{
    private GlobalData _global;
    private MainAspect _aspect;

    public void SetWorld(MainAspect aspect,GlobalData global)
    {
        _aspect = aspect;
        _global = global;
    }

    public void CharacterAppear()
    {
        //_global.ScharacterScript.gameObject.SetActive(true);
    }

    public void ClimbEnd()
    {
        
    }
    
}
