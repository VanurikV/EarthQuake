using System.Collections.Generic;
using System.IO;
using System.Linq;
using Leopotam.EcsProto;
using Leopotam.EcsProto.QoL;
using Newtonsoft.Json;
using UnityEngine;


sealed partial class InitAllSystem : IProtoInitSystem
{
    [DI] GlobalData _global;
    [DI] private MainAspect _aspect;

    public void Init(IProtoSystems systems)
    {
        _global.AllPrefab = new Dictionary<int, GameObject>();
        _global.CurrentLevel = Settings.GetLevel();

        LoadCurMap();
        LoadAllPrefabs();
        Debug.Log("--Load Data Complite--");

        FindContainer();

        //CreateObject();
        CreateBorder();
        CreateRock();
        CreateDiamond();
        CreateGrass();
        

    }
}