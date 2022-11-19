using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerIfTest : DoorController
{
   public int Enemies;
   public int Buttons;

   public void EnemyDie()
   {
      Enemies--;
      TryOpen();
   }

   public void ButtonPress()
   {
      Buttons++;
      TryOpen();
   }
   
   public void ButtonUnpress()
   {
      Buttons--;
      TryOpen();
   }

   public virtual void TryOpen()
   {
      if (Enemies == 0 && Buttons == 0)
      {
         Hide();
      }
      else
      {
         Show();
      }
   }
}
