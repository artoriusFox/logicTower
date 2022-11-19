using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public string Msg;
    private bool _open = false;
    public Animator Animator;
    public GameObject[] Objects;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                OpenDialog();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            CloseDialog();
        }

        
    }

    private void OpenDialog()
    {
        _open = true;
        Text.text = Msg;
        Animator.SetBool("Open", _open);
        EnableOnInteract();
    }
    
    private void CloseDialog()
    {
        _open = false;
        Animator.SetBool("Open", _open);
    }

    public void EnableOnInteract()
    {
        if (Objects != null && Objects.Length > 0)
        {
            foreach (var o in Objects)
            {
                o.SetActive(true);
            }
        }
    }

}
