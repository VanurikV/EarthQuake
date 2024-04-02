using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiamondScript : MonoBehaviour, IFall
{
    private Animator _animator;
    private Rigidbody2D _body;
    private readonly int _rotateHash = Animator.StringToHash("RotateAnimation");

    private float Delay;
    private float PrevRotate;

    private float RotateMin = 10;
    private float RotateMax = 30;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Delay = Random.Range(RotateMin, RotateMax);
        PrevRotate = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - PrevRotate > Delay)
        {
            Delay = Random.Range(RotateMin, RotateMax);
            PrevRotate = Time.time;
            _animator.Play(_rotateHash);
        }
    }

    public void Fall(bool fall)
    {
        _body.simulated = fall;
    }
}