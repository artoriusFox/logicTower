using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public string NameNewScene;
    public int SaveStateFase;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            TeleportPlayer();
        }
    }

    public void TeleportPlayer()
    {
        SceneManager.LoadScene(NameNewScene);
        SaveState();
    }

    private void SaveState()
    {
       GameManager.Instance.SaveState(SaveStateFase);
    }
}
