using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData
{
    public EcsGate EcsGate;

    public SoundManager SoundManager;
    public Controls Controls;
 
    public Dictionary<int, GameObject> AllPrefab;
    public int CurrentLevel;
    
    
    public MapLevel Map;
    
    
    public GameObject StoneBlockContainer;
    public GameObject GroundContainer;
    public GameObject CharacterContainer;


    
}