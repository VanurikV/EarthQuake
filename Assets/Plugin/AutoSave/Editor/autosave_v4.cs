// *******************************************************
// Copyright 2013 Daikon Forge, all rights reserved under 
// US Copyright Law and international treaties
// *******************************************************
//скрипт авто сохранения при нажатии на Play
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class OnUnityLoad
{

	static OnUnityLoad()
	{
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
	}

    private static void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state != PlayModeStateChange.ExitingEditMode) return;
        
        Debug.Log("Auto-Saving scene :=" + SceneManager.GetActiveScene().name);

        EditorSceneManager.SaveOpenScenes();
        AssetDatabase.SaveAssets();
    }

}