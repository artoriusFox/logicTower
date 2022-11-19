using UnityEngine;

namespace Code.Scripts.Code
{
    public class MoveUp: Function
    {
        public MoveUp(string fullLine) : base(fullLine)
        {
        }
        public override void Func(Robot mainTarget)
        {
            mainTarget.UpdateMotor(0f, 1f);
        }
    }
}