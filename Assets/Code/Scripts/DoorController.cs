using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorController : MonoBehaviour
{
    private TilemapRenderer _renderer;
    private TilemapCollider2D _collider;
    
    private void Start()
    {
        _renderer = GetComponent<TilemapRenderer>();
        _collider = GetComponent<TilemapCollider2D>();
    }
    

    protected void Hide()
    {
        _renderer.enabled = false;
        _collider.enabled = false;
    }

    protected void Show()
    {
        _renderer.enabled = true;
        _collider.enabled = true;
    }
}
