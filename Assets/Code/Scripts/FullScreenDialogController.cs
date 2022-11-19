using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FullScreenDialogController : MonoBehaviour
{
    private bool _open = false;
    private bool _show = false;
    public Animator Animator;
    public string Msg;
    public TextMeshProUGUI Text;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player") && !_open)
        {
            _open = true;
            _show = true;
            Text.text = Msg;
            Animator.SetBool("Show", _show);
            GameManager.Instance.player.StopPlayer = _show;
        }
    }

    private void Update()
    {
        if (_show)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _show = false;
                GameManager.Instance.player.StopPlayer = _show;
                Animator.SetBool("Show", _show);
            }
        }
    }
}
