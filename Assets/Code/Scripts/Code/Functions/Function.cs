using System;
using UnityEngine;

namespace Code.Scripts.Code
{
    public class Function
    {
        public string FullLine;
        public Function(string fullLine)
        {
            this.FullLine = fullLine;
        }

        public virtual void Func(Robot mainTarget)
        {
           
        }
    }
}