using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VHierarchy.Libs;

public class GrassScript : MonoBehaviour
{
    
    private SpriteRenderer _spriteRenderer;

    public Sprite[] StoneSprites;

    public Animator _animator;
    private AudioSource _grassFadeFx;
    
    void Start()
    {
        _animator = GetComponent("Animator")as Animator ;
        _grassFadeFx = GetComponent<AudioSource>();
        
        _spriteRenderer = GetComponent<SpriteRenderer>();
        //_spriteRenderer.sprite = StoneSprites[Random.Range(0,StoneSprites.Length)];

        int x = (int)(transform.localPosition.x/64f) % 8;
        int y = (int)(transform.localPosition.y/-64f) % 8;

        _spriteRenderer.sprite = StoneSprites[y*8+x];

    }

    public void Fade()
    {
        _animator.enabled = true;
        _grassFadeFx.Play();
    }
    

    public void onAnamationEnd()
    {
        gameObject.Destroy();
    }
    
    
}
