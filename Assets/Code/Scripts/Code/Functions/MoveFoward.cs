using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Scripts.Code
{
    public class MoveFoward : Function
    {
        public MoveFoward(string fullLine) : base(fullLine)
        {
        }

        public override void Func(Robot mainTarget)
        { 
            mainTarget.UpdateMotor(1f, 0f);
        }
    }
}