using System;
using System.Collections;
using System.Collections.Generic;
using Code.Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class Box : Pushable
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        MoveWithPlayer(col);
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        MoveWithPlayer(col);
    }

    private void MoveWithPlayer(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.F))
            {
                var x = Input.GetAxis("Horizontal");
                var y = Input.GetAxis("Vertical");
                UpdateMotor(x,y);    
            }
        }
    }
}
