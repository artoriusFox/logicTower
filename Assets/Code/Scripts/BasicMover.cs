using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Scripts
{
    public class BasicMover : MonoBehaviour
    {
        public String[] LockedLayers;
        protected Vector3 MoveDelta;
        public BoxCollider2D Collider2D;
        public virtual void Start()
        {
            Collider2D = GetComponent<BoxCollider2D>();
        }
        protected virtual void BlockMovementIfNotAllowed()
        {
            if(LockedLayers.Length == 0) return;
            RaycastHit2D hitY, hitX;
            
            hitY = Physics2D.BoxCast(
                transform.position,
                Collider2D.size,
                0,
                new Vector2(0,MoveDelta.y * Time.fixedDeltaTime),
                Mathf.Abs(MoveDelta.y * Time.fixedDeltaTime),
                LayerMask.GetMask(LockedLayers));
            
            hitX = Physics2D.BoxCast(
                transform.position,
                Collider2D.size,
                0,
                new Vector2(MoveDelta.x * Time.fixedDeltaTime,0),
                Mathf.Abs(MoveDelta.x * Time.fixedDeltaTime),
                LayerMask.GetMask(LockedLayers));
            
            if (hitX.collider != null) MoveDelta.x = 0f;
            if (hitY.collider != null) MoveDelta.y = 0f;
        }

        protected virtual void Move()
        {
           // Debug.Log(transform.name +": " +MoveDelta+ " | "+MoveDelta * Time.deltaTime+" | "  + transform.transform.position);
            transform.Translate(MoveDelta * Time.fixedDeltaTime);
        }
    }
    
}