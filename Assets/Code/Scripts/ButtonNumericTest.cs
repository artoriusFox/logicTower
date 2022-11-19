using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNumericTest :Button
{
    public Collider2D TargetMessage;
    public void OnCollisionStay2D(Collision2D collision)
    {
        TargetMessage.SendMessage("SetTextToHud", "<color=\"grey\">numerico</color> caixasNoBotao = <color=\"blue\">"+NumberOfElementsPressing+"</color>");
    }
}
