using UnityEngine;

namespace Code.Scripts
{
    public class Pushable : BasicMover
    {
        protected void UpdateMotor(float x, float y)
        {
            UpdateMotor(new Vector3(x, y));
            
        }

        protected void UpdateMotor(Vector3 input)
        {
            MoveDelta = new Vector3(input.x * GameManager.Instance.player.XSpeed, 
                                    input.y * GameManager.Instance.player.YSpeed);
            
            BlockMovementIfNotAllowed();
            
            Move();
        }

    }
}