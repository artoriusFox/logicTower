using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private bool _itemGive = false;
    public Sprite OpenSprite;
    public bool SwordChest;
    private void OnCollisionStay2D(Collision2D col)
    {
        if(col.collider.CompareTag("Player") && !_itemGive ){
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (SwordChest)
                {
                    GameManager.Instance.player.GiveSword();
                }
                else
                {
                    GameManager.Instance.GiveTablet();
                   
                }
                this.GetComponent<SpriteRenderer>().sprite = OpenSprite;
                _itemGive = true;

            }
        }
    }
}
