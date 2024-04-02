using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    
    private SpriteRenderer _spriteRenderer;

    public Sprite[] StoneSprites;
    
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = StoneSprites[Random.Range(0,StoneSprites.Length)];
    }

  
}
