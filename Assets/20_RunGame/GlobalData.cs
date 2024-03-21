using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class GlobalData
    {
        public EcsGate EcsGate;
        
        public SoundManager SoundManager;
        
        
        public Controls controls;

        public int CurrentLevel;
        
        public MapLevel Map;
        
        public Dictionary<int, GameObject> AllPrefab;


        public Camera Camera;
        public GameObject StoneBlockContainer;
        public GameObject GroundContainer;
        
        public GameObject CharacterContainer;
        public GameObject Character;
        public CharacterScript ScharacterScript;


    }

