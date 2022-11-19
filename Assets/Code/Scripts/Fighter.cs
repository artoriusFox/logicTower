using System.Collections;
using System.Collections.Generic;
using Code;
using UnityEngine;

public class Fighter : Mover
{
    public int HitPoint = 5;
    public float PushRecoverySpeed = 0f;
    
    protected float ImmuneTime = 0.5f;
    protected float LastImmune; 

    protected Vector3 PushDirection;

    protected virtual void ReceiveDamage(Damage dmg)
    {
  
        if (Time.time - LastImmune > ImmuneTime)
        {
            GameManager.Instance.floatingTextManager.Show(dmg.DamageAmount.ToString(),
                20,
                Color.red,
                transform.position,
                Vector3.up * 0.05f,
                0.3f);

            LastImmune = Time.time;
            HitPoint -= dmg.DamageAmount;
            PushDirection = (transform.position - dmg.Origin).normalized * dmg.PushForce;

            if (HitPoint <= 0)
            {
                HitPoint = 0; 
                Death();
            }
        }
    }

    protected virtual void Death()
    {
    }

    protected override void UpdateMotor(Vector3 input)
    {
        MoveDelta = new Vector3(input.x * XSpeed, input.y * YSpeed);
        
        SwitchSpriteDirection();
        
        PushDirection = LowerPushDirection();
        
        MoveDelta += PushDirection;
        
        BlockMovementIfNotAllowed();
        
        Move();
    }

    private Vector3 LowerPushDirection()
    {
        return Vector3.Lerp(PushDirection, Vector3.zero, PushRecoverySpeed);
    }
}
