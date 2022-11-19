namespace Code.Scripts.Code
{
    public class MoveDown: Function
    {
        public MoveDown(string fullLine) : base(fullLine)
        {
        }
        public override void Func(Robot mainTarget)
        { 
            mainTarget.UpdateMotor(0f, -1f);
        }
    }
}