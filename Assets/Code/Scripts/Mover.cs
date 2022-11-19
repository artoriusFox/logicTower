using System;
using Code.Scripts;
using UnityEngine;

public class Mover : BasicMover
{
  
    private Rigidbody2D _rigidbody2D;
    
    public float YSpeed = 4f;
    public float XSpeed = 5f;


    public void UpdateMotor(float x, float y)
    {
        UpdateMotor(new Vector3(x, y));
    }

    protected virtual void UpdateMotor(Vector3 input)
    {
        MoveDelta = new Vector3(input.x * XSpeed, input.y * YSpeed);
        
        SwitchSpriteDirection();
    
        BlockMovementIfNotAllowed();
        
        Move();
    }

    public void SwitchSpriteDirection()
    {
        if (MoveDelta.x > 0) transform.localScale = Vector3.one;
        else if(MoveDelta.x < 0) transform.localScale = new Vector3(-1,1);
    }


    protected override void Move()
    {
        base.Move();
        if (MoveDelta.x != 0 || MoveDelta.y != 0) 
            StartWalkAnimation();
        else 
            StopWalkAnimation();
        
        
    }

    protected virtual void StartWalkAnimation()
    {
    }

    protected virtual void StopWalkAnimation()
    {
    }
}
