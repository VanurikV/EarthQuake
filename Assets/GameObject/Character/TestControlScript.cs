using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestControlScript : MonoBehaviour
{
    private Controls _controls;

    public float Speed;
    public CharacterScript characterScript;
    
    void Awake()
    {
        _controls = new Controls();
    }

    
    void Update()
    {
        Vector3 move = _controls.ControlMap.Keyboard.ReadValue<Vector2>();
        
        transform.localPosition += move* Speed * Time.deltaTime;

        
        
        
        
    }

    private void OnEnable()
    {
        _controls.Enable();
   }

    private void OnDisable()
    {
        _controls.Disable();
    }
}


