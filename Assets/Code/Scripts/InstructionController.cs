using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InstructionController : MonoBehaviour
{
    private bool _activate = false;
    public string InitialText;
    public TextMeshProUGUI Text;
    

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player") && !_activate)
        {
            _activate = true;
            SetTextToHud(InitialText);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player") && _activate)
        {
            SetTextToHud("");
            _activate = false;
        }
    }

    public void SetTextToHud(string text)
    {
        if(_activate) this.Text.text = text;
    }
}
