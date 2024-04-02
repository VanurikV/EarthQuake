using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public LevelManagerScript LevelManager;

    [Header("Cursor")] public GameObject CursorPrefab;
    public GameObject CursorContainer;
    public GameObject Cursor;

    [Space] public int CursorBlockId;

    [Space(50)] public int CursorPosX;
    public int CursorPosY;


    private Vector2 _mousePosition;
    private float _leftMouseButton;


    private Vector2 _offset;
    private bool _gridSnap;
    private bool _gridTogle;
    private float _toggleTime;


    private void Awake()
    {
        _offset = new Vector2(0, -50);
        Cursor = GameObject.Instantiate(CursorPrefab, CursorContainer.transform);
    }


    void Start()
    {
    }


    void Update()
    {
        GridSnap();
        MoveCursor();
        CheckPasteBlock();
    }


    public void ChangeCursor(GameObject BlockPrefab, int PrefabId)
    {
        foreach (Transform child in Cursor.GetComponentsInChildren(typeof(Transform), true))
        {
            if (child == Cursor.transform) continue;
            GameObject.Destroy(child.gameObject);
        }

        GameObject o = Instantiate(BlockPrefab, Cursor.transform);
        o.transform.localPosition = new Vector3(0, 0, 0);
        CursorBlockId = PrefabId;
    }


    private void CheckPasteBlock()
    {
        if (_gridSnap == false) return;
        if (CursorPosX >= Const.LevelDx) return;
        if (CursorPosY >= Const.LevelDy) return;


        _leftMouseButton = LevelManager.EditorControl.ActionMap.MouseClickL.ReadValue<float>();
        if (_leftMouseButton < 0.9) return;

        LevelManager.PasteBlock(CursorPosX, CursorPosY, CursorBlockId);
    }

    private void MoveCursor()
    {
        _mousePosition = LevelManager.EditorControl.ActionMap.MouseAction.ReadValue<Vector2>();
        _mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(_mousePosition.x, _mousePosition.y, 10));
        _mousePosition += new Vector2(0, -32-16);
        _mousePosition = _mousePosition * 2 - _offset * 2;

        CursorPosX = (int) (_mousePosition.x / 64f);
        CursorPosY = (int) (_mousePosition.y / 64f) * -1;


        if (_gridSnap)
        {
            Cursor.transform.localPosition = new Vector3(CursorPosX * 64, (CursorPosY) * -64);
        }
        else
        {
            Cursor.transform.localPosition = _mousePosition;
        }
    }


    private void GridSnap()
    {
        float t = LevelManager.EditorControl.ActionMap.GridSnap.ReadValue<float>();
        _toggleTime += Time.deltaTime;


        if (t == 1 && _toggleTime > 0.5)
        {
            _gridSnap = _gridSnap ^ true;
            _toggleTime = 0;
        }
    }
}