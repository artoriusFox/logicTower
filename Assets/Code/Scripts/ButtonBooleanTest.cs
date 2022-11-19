using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonBooleanTest : Button
{
    public Collider2D TargetMessage;

    public override void ActionReachElementNunber()
    {
        base.ActionReachElementNunber();
        
        TargetMessage.SendMessage("SetTextToHud", "<color=\"grey\">booleano</color> caixaNoBotao = <color=\"green\">verdadeiro</color>");
    }
    
    public override void ActionDontReachElementNunber()
    {
        base.ActionDontReachElementNunber();
        TargetMessage.SendMessage("SetTextToHud", "<color=\"grey\">booleano</color> caixaNoBotao = <color=\"red\">falso</color>");
    }
}
