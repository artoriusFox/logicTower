using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Animator Animator;
    public int DamagePoint;
    public float PushForce;
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            Animator.SetTrigger("Swing");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        OnCollide(col.collider);
    }

    private void OnCollide(Collider2D coll)
    {
        if (coll.CompareTag("Fighter") && coll.name != "Player")
        {
            Debug.Log(coll.name);
            var damage = new Damage(transform.position,DamagePoint,PushForce);
            coll.SendMessage("ReceiveDamage",damage);
        }
    }
}
