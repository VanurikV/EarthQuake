using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private Dictionary<int, int> _animState;

    private Animator _animator;

    private EcsGate _ecsGate;
    private AudioSource _footStepFx;
    private void Awake()
    {
        //_animator.GetComponent<Animator>(); NOT WORK
        _animator = GetComponent("Animator")as Animator ;
        _footStepFx = GetComponent<AudioSource>();
        
        _animState = new Dictionary<int, int>();
        _animState.Add((int)CharacterAnimation.IdleFrontAnim, Animator.StringToHash("IdleFrontAnim"));
        _animState.Add((int)CharacterAnimation.IdleLeftAnim, Animator.StringToHash("IdleLeftAnim"));
        _animState.Add((int)CharacterAnimation.IdleRightAnim, Animator.StringToHash("IdleRightAnim"));
        _animState.Add((int)CharacterAnimation.IdleBackAnim, Animator.StringToHash("IdleBackAnim"));

        _animState.Add((int)CharacterAnimation.MoveFrontAnim, Animator.StringToHash("MoveFrontAnim"));
        _animState.Add((int)CharacterAnimation.MoveLeftAnim, Animator.StringToHash("MoveLeftAnim"));
        _animState.Add((int)CharacterAnimation.MoveRightAnim, Animator.StringToHash("MoveRightAnim"));
        _animState.Add((int)CharacterAnimation.MoveBackAnim, Animator.StringToHash("MoveBackAnim"));

        _animState.Add((int)CharacterAnimation.ClimbFrontAnim, Animator.StringToHash("ClimbFrontAnim"));
        _animState.Add((int)CharacterAnimation.ClimbLeftAnim, Animator.StringToHash("ClimbLeftAnim"));
        _animState.Add((int)CharacterAnimation.ClimbRightAnim, Animator.StringToHash("ClimbRightAnim"));
        _animState.Add((int)CharacterAnimation.ClimbBackAnim, Animator.StringToHash("ClimbBackAnim"));

        _ecsGate = GameObject.Find("ECS_Gate").GetComponent<EcsGate>();

    }


    public void RunAnimation(Vector2Int dir)
    {
        if (dir.x > 0) RunAnimation(CharacterAnimation.MoveRightAnim);
        if (dir.x < 0) RunAnimation(CharacterAnimation.MoveLeftAnim);
        if (dir.y > 0) RunAnimation(CharacterAnimation.MoveFrontAnim);
        if (dir.y < 0) RunAnimation(CharacterAnimation.MoveBackAnim);
    }
    
    public void RunAnimation(CharacterAnimation anim)
    {
        
        _animator.Play(_animState[(int)anim]);
        
        if (anim == CharacterAnimation.IdleFrontAnim)
        {
            _footStepFx.Stop();
        }
        else
        {
            if(_footStepFx.isPlaying) return;
            _footStepFx.Play();            
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("--HIT--  "+other);
    }


    public void Climb(Vector2 dir)
    {
        if(dir.x>0) RunAnimation(CharacterAnimation.ClimbRightAnim);
        if(dir.x<0) RunAnimation(CharacterAnimation.ClimbLeftAnim);
        if(dir.y>0) RunAnimation(CharacterAnimation.ClimbFrontAnim);
        if(dir.y<0) RunAnimation(CharacterAnimation.ClimbBackAnim);
    }
    
    public void onAnamationClimbEnd()
    {
        RunAnimation(CharacterAnimation.IdleFrontAnim);
    }
}