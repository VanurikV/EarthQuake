using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VHierarchy.Libs;

public class WarpInScript : MonoBehaviour
{
    private EcsGate _ecsGate;
    
    
    public void SetGate(EcsGate gate)
    {
        _ecsGate = gate;
    }

    public void onCharacterEnable()
    {
        _ecsGate.CharacterAppear();
    }

    public void onAnamationEnd()
    {
        gameObject.Destroy();
    }
    
}
