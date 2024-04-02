using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public LevelManagerScript LevelManager;
    
    public GameObject GridPrefab;
    public GameObject GridContainer;

    
    private bool _gridTogle;
    private float _toggleTime;
    
    
    void Start()
    {
        CreateGrid();
    }

    
    void Update()
    {
        GridTogle();
    }
    
    
    private void CreateGrid()
    {
        
        
        int dx = Const.LevelDx;
        int dy = Const.LevelDy;

        for (int x = 0; x < dx; x++)
        {
            for (int y = 0; y < dy; y++)
            {
                GameObject o = GameObject.Instantiate(GridPrefab, GridContainer.transform);
                o.name = "x:=" + x.ToString("D2") + "   y:=" + y.ToString("D2");
                o.transform.localPosition = new Vector3(x * 64, -y * 64, 0);
            }
        }
    }
    
    private void GridTogle()
    {
        float t= LevelManager.EditorControl.ActionMap.GridTogle.ReadValue<float>();
        _toggleTime += Time.deltaTime;
        
        
        if (t == 1 && _toggleTime>0.5)
        {
            _gridTogle =_gridTogle ^ true;
            _toggleTime = 0;
            
            if (_gridTogle)
            {
                GridContainer.SetActive(true);
            }
            else
            {
                GridContainer.SetActive(false);
            }
        }
    }
}
