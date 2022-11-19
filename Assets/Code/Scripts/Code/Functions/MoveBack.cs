namespace Code.Scripts.Code
{
    public class MoveBack:Function
    {
        public MoveBack(string fullLine) : base(fullLine)
        {
        }
        
        public override void Func(Robot mainTarget)
        { 
            mainTarget.UpdateMotor(-1f, 0f);
        }
    }
}