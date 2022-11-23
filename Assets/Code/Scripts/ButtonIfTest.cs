using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonIfTest : Button
{
   private bool _alreadyPress = false;
   public override void ActionReachElementNunber()
   {
      Renderer.sprite = SpritePress;
      Press = true;
   }

   public override void ActionDontReachElementNunber()
   {
      Renderer.sprite = SpriteUnpress;
   }

   public override void actionOnAddItem(Collision2D col)
   {
     
      if (CanPress.Contains(col.transform.tag))
      {
         if (!_alreadyPress)
         {
            base.actionOnAddItem(col);
            _alreadyPress = true;
            if(!string.IsNullOrEmpty(PressCommand))  Target.SendMessage(PressCommand);
         }
      }

      
   }

   public override void actionOnRemoveItem(Collision2D col)
   {
      if (CanPress.Contains(col.transform.tag))
      {
         if (_alreadyPress)
         {
            base.actionOnRemoveItem(col);
            _alreadyPress = false;
            if(!string.IsNullOrEmpty(UnpressCommand)) Target.SendMessage(UnpressCommand);
         }
      }
   }
}
