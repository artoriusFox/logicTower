using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Scripts.Code
{
    public class MainLoop
    {
        public Robot MainTarget;
        public List<Function> Sequence;
        private float _waitTime;
        

        public MainLoop(Robot mainTarget, List<Function> sequence)
        {
            this.MainTarget = mainTarget;
            this.Sequence = sequence;
            this._waitTime = 0.05f; 
        }
        public IEnumerator Play()
        {
            WaitForSeconds wait = new WaitForSeconds(_waitTime);
            foreach (Function fun in this.Sequence)
            {
               
                fun.Func(this.MainTarget);
                yield return wait;
            }
            yield return new WaitForSeconds(1f);
            VerificationSucess();
        }

        private void VerificationSucess()
        {
            MainTarget.SetUnblocked();
            if (!MainTarget.Success)
            {
                MainTarget.Respawn();
            }
        }
    }
}