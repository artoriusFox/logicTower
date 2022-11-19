using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Button : MonoBehaviour
{
    public int NumberOfElementsToActivate = 2;
    public int NumberOfElementsPressing = 0;
    public List<string> CanPress;
    public Sprite SpritePress;
    public Sprite SpriteUnpress;
    protected SpriteRenderer Renderer;
    public bool KeepPress;
    protected bool Press = false;
    public string PressCommand;
    public string UnpressCommand;
    public Collider2D Target;

    private void Awake()
    {
        Renderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        actionOnAddItem(col);
    }

    public virtual void actionOnAddItem(Collision2D col)
    {
        if (CanPress.Contains(col.transform.tag))
            NumberOfElementsPressing++;
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        actionOnRemoveItem(col);
    }

    public virtual void actionOnRemoveItem(Collision2D col)
    {
        if(CanPress.Contains(col.transform.tag))
            NumberOfElementsPressing--;
    }

    private  void LateUpdate()
    {
        if (NumberOfElementsPressing >= NumberOfElementsToActivate)
        {
            ActionReachElementNunber();
        }
        else
        {
            if (SpritePress && !KeepPress)
            {
                ActionDontReachElementNunber();
            }
        }
    }
    public virtual void ActionReachElementNunber()
    {
        Renderer.sprite = SpritePress;
        Press = true;
       // Debug.Log(target.transform.name + " " + pressCommand);
        if(!string.IsNullOrEmpty(PressCommand))  Target.SendMessage(PressCommand);
    }
    public virtual void ActionDontReachElementNunber()
    {
        Renderer.sprite = SpriteUnpress;
       // Debug.Log(target.transform.name + " " + unpressCommand);
        if(!string.IsNullOrEmpty(UnpressCommand)) Target.SendMessage(UnpressCommand);
    }
}
