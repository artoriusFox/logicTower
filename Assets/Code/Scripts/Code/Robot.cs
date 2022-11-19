using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Robot : Mover
{
    public bool Success = false;
    public bool Blocked = false;
    public Vector3 Spawn;
    public Collider2D Target;
    public string Msg;
    public string MsgFail;
    private Coroutine _coroutine;
    protected override void Move()
    {
        transform.Translate(MoveDelta);
    }

    public override void Start()
    {
        base.Start();
        Spawn = transform.position;
    }

    public virtual void SetSucess()
    {
        Success = true;
        Blocked = true;
        if(Target != null)Target.SendMessage(Msg);
    }

    public virtual void SetFail()
    {
        Success = false;
        Blocked = false;
        if(Target != null)Target.SendMessage(MsgFail);
    }

    public virtual void SetBlocked()
    {
        Blocked = true;
    }
    
    public virtual void SetUnblocked()
    {
        Blocked = false;
    }
    
    protected override void BlockMovementIfNotAllowed()
    {
        if(LockedLayers.Length == 0) return;
            
        RaycastHit2D hitY, hitX;
            
        hitY = Physics2D.BoxCast(
            transform.position,
            Collider2D.size,
            0,
            new Vector2(0,MoveDelta.y * Time.deltaTime),
            Mathf.Abs(MoveDelta.y * Time.deltaTime),
            LayerMask.GetMask(LockedLayers));
            
        hitX = Physics2D.BoxCast(
            transform.position,
            Collider2D.size,
            0,
            new Vector2(MoveDelta.x * Time.deltaTime,0),
            Mathf.Abs(MoveDelta.x * Time.deltaTime),
            LayerMask.GetMask(LockedLayers));

        if (hitX.collider != null || hitY.collider != null)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        SetUnblocked();
        StopCoroutine(_coroutine);
        transform.position = Spawn;
        GameManager.Instance.floatingTextManager.Show("bip-bop? :(",
            20,
            Color.blue,
            transform.position,
            Vector3.up * 0.5f,
            0.5f);
    }

    public void SetCoroutinePlaying(Coroutine coruotine)
    {
        _coroutine = coruotine;
    }
}
