using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerIfTest2 : DoorControllerIfTest
{
    public int NecessaryButtons;

    public override void TryOpen()
    {
        if (Enemies == 0 || Buttons == NecessaryButtons)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }
}
