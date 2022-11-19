using UnityEngine;

namespace Code
{
    public class Damage
    {
        public Vector3 Origin;
        public int DamageAmount;
        public float PushForce;

        public Damage(Vector3 origin, int damageAmount, float pushForce)
        {
            Origin = origin;
            DamageAmount = damageAmount;
            PushForce = pushForce;
        }
    }
}