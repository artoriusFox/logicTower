using System;
using UnityEngine;

namespace Code.Scripts.Code
{
    
    public class Enemy : Fighter
    {   public float TriggerLenght = 0.3f;
        public float ChaseLenght = 3f;
        public bool Chasing;
        public bool CollidingWithPlayer;
        public Transform PlayerTransform;
        private Vector3 _startPosition;
        public ContactFilter2D Filter;
        private BoxCollider2D _hitbox;
        public int DamagePoint = 1;
        public float PushForce = 5;
        private Animator _animator;
        public Collider2D Target;
        public string Command;

        public override void Start()
        {
            base.Start();
            PlayerTransform = GameManager.Instance.player.transform;
            _startPosition = transform.position;
            _hitbox = transform.GetComponent<BoxCollider2D>();
            _animator = transform.GetComponent<Animator>();
        }
        private void FixedUpdate()
        {
            if (Vector3.Distance(PlayerTransform.position, _startPosition) < ChaseLenght)
            {
                if (Vector3.Distance(PlayerTransform.position, _startPosition) < TriggerLenght) 
                    Chasing = true;

                if (Chasing)
                {
                    if (!CollidingWithPlayer)
                    {
                        UpdateMotor((PlayerTransform.position - transform.position).normalized);
                    }
                }
                else
                {
                    UpdateMotor(_startPosition - transform.position);
                }
            }
            else
            {
                UpdateMotor(_startPosition - transform.position);
                Chasing = false;
            }
            
        }

        public void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log(col.transform.tag);
            if(col.transform.CompareTag("Player")){
                CollidingWithPlayer = true;
                col.transform.SendMessage("ReceiveDamage",new Damage(transform.position,DamagePoint,PushForce));
            }
        }

        public void OnCollisionStay2D(Collision2D col)
        {  
            if(col.transform.CompareTag("Player")){
                CollidingWithPlayer = true;
                UpdateMotor(_startPosition - transform.position);
            }
        }

        public void OnCollisionExit2D(Collision2D col)
        {
            Debug.Log(col.transform.tag);
            if(col.transform.CompareTag("Player")){
                CollidingWithPlayer = false;
            }
        }
        protected override void StartWalkAnimation()
        {
            _animator.SetBool("walking",true);
        }

        protected override void StopWalkAnimation()
        {
            _animator.SetBool("walking",false);
        }

        protected override void Death()
        {
            if (Target != null) Target.SendMessage(Command);
            
            GameManager.Instance.floatingTextManager.Show("Morri :(",
                20,
                Color.cyan,
                transform.position,
                Vector3.up * 0.4f,
                0.3f);
            
            Destroy(gameObject);
        }
    }
    
}