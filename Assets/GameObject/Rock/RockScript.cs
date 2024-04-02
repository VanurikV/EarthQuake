using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour, IFall
{

    private SpriteRenderer _spriteRenderer;

    public Sprite[] StoneSprites;

    private Rigidbody2D _body;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
    }



    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = StoneSprites[Random.Range(0, StoneSprites.Length)];
    }

    public void Fall(bool fall)
    {
        _body.simulated = fall;
    }
}
    



