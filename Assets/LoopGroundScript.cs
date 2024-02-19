using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopGroundScript : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    private float _width = 10f;

    private SpriteRenderer _spriteRenderer;

    private Vector2 _startSize;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _startSize = new Vector2(_spriteRenderer.size.x, _spriteRenderer.size.y);
    }

    private void Update()
    {
        _spriteRenderer.size = new Vector2(_spriteRenderer.size.x + speed * Time.deltaTime, _spriteRenderer.size.y);

        if (_spriteRenderer.size.x > _width)
        {
            _spriteRenderer.size = _startSize;
        }
    }
}
