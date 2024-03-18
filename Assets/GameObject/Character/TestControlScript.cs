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

        if(Mathf.Round(move.x)==1)characterScript.RunAnimation(CharacterAnimation.MoveRightAnim);
        if(Mathf.Round(move.x)==-1)characterScript.RunAnimation(CharacterAnimation.MoveLeftAnim);
        if(Mathf.Round(move.y)==-1)characterScript.RunAnimation(CharacterAnimation.MoveFrontAnim);
        if(Mathf.Round(move.y)==1)characterScript.RunAnimation(CharacterAnimation.MoveBackAnim);
        
        if(move.x+move.y==0) characterScript.RunAnimation(CharacterAnimation.IdleFrontAnim);
        
        
        
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


